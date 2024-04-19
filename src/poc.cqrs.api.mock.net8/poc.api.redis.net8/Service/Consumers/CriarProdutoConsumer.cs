using Confluent.Kafka;
using poc.api.redis.Model;
using poc.api.redis.Service.Persistence;
using System.Text.Json;
namespace poc.api.redis.Service.Consumers;

public class CriarProdutoConsumer : BackgroundService
{
    private readonly string _topic;
    private readonly ConsumerConfig _config;
    private readonly IServiceScopeFactory _serviceScopeFactory;
    private readonly ILogger<CriarProdutoConsumer> _logger;

    public CriarProdutoConsumer(IConfiguration configuration, ILogger<CriarProdutoConsumer> logger, IServiceScopeFactory serviceScopeFactory)
    {
        _config = new ConsumerConfig
        {
            BootstrapServers = configuration["Kafka:BootstrapServers"],
            GroupId = configuration["Kafka:GroupId:Produto"],
            AutoOffsetReset = AutoOffsetReset.Earliest
        };
        _topic = configuration["Kafka:Topic:Produto:CriarProduto"];
        _logger = logger;
        _serviceScopeFactory = serviceScopeFactory;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation($"Consumer > ExecuteAsync > Produto > {_topic} > Redis...");
        using var consumer = new ConsumerBuilder<Ignore, string>(_config).Build();
        consumer.Subscribe(_topic);

        // Defina um tempo limite para a operação de consumo
        TimeSpan consumeTimeout = TimeSpan.FromSeconds(5);

        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                // Use o tempo limite na chamada de Consume
                var consumeResult = consumer.Consume(consumeTimeout);

                // Se não houver mensagem, pausa antes de continuar
                if (consumeResult == null)
                {
                    await Task.Delay(1000, stoppingToken); // Pausa de 1 segundo
                    continue;
                }

                var model = JsonSerializer.Deserialize<Produto>(consumeResult.Message.Value);

                using var scope = _serviceScopeFactory.CreateScope();
                var produtoService = scope.ServiceProvider.GetRequiredService<IProdutoService>();
                await produtoService.Post(model);

                _logger.LogInformation($"Mensagem consumida do tópico {_topic}: {consumeResult.Message.Value}");
            }
            catch (ConsumeException e)
            {
                _logger.LogError($"Erro ao consumir mensagem: {e.Error.Reason}");
            }
        }

        consumer.Close();
    }
}

