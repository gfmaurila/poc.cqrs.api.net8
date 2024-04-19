using Confluent.Kafka;
using poc.api.redis.Model;
using poc.api.redis.Service.Persistence;
using System.Text.Json;
namespace poc.api.redis.Service.Consumers;

public class ProdutoConsumer : BackgroundService
{
    private readonly ConsumerConfig _config;
    private readonly IServiceScopeFactory _serviceScopeFactory;
    private readonly ILogger<ProdutoConsumer> _logger;
    private readonly Dictionary<string, Action<string>> _topicHandlers;

    public ProdutoConsumer(IConfiguration configuration, ILogger<ProdutoConsumer> logger, IServiceScopeFactory serviceScopeFactory)
    {
        _config = new ConsumerConfig
        {
            BootstrapServers = configuration["Kafka:BootstrapServers"],
            GroupId = configuration["Kafka:GroupId:Produto"],
            AutoOffsetReset = AutoOffsetReset.Earliest
        };
        _logger = logger;
        _serviceScopeFactory = serviceScopeFactory;

        // Map each topic to its corresponding handler method
        _topicHandlers = new Dictionary<string, Action<string>>
        {
            { configuration["Kafka:Topic:Produto:CriarProduto"], CriarProduto },
            { configuration["Kafka:Topic:Produto:AlterarProduto"], AlterarProduto },
            { configuration["Kafka:Topic:Produto:RemoverProduto"], RemoverProduto }
        };
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _config.EnableAutoCommit = false; // Desabilita o commit automático de offsets
        _config.MaxPollIntervalMs = 300000; // Ajusta conforme necessário

        using var consumer = new ConsumerBuilder<Ignore, string>(_config).Build();
        consumer.Subscribe(_topicHandlers.Keys);

        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                var consumeResult = consumer.Consume(stoppingToken);
                if (consumeResult?.Message != null)
                {
                    _logger.LogInformation($"Mensagem consumida do tópico {consumeResult.Topic} com offset {consumeResult.Offset}.");

                    if (_topicHandlers.TryGetValue(consumeResult.Topic, out var handler))
                    {
                        try
                        {
                            handler(consumeResult.Message.Value);
                            consumer.Commit(consumeResult);
                            _logger.LogInformation($"Mensagem do tópico {consumeResult.Topic} com offset {consumeResult.Offset} processada e confirmada com sucesso.");
                        }
                        catch (Exception ex)
                        {
                            _logger.LogError($"Erro ao processar a mensagem do tópico {consumeResult.Topic} com offset {consumeResult.Offset}: {ex.Message}. A mensagem será reprocessada.");
                        }
                    }
                }
            }
            catch (OperationCanceledException)
            {
                break; // Sair do loop se o token de cancelamento for acionado
            }
            catch (ConsumeException e)
            {
                _logger.LogError($"Erro de consumo: {e.Error.Reason}");
            }
            catch (Exception e)
            {
                _logger.LogError($"Erro inesperado: {e.Message}");
            }
        }

        consumer.Close();
    }




    private void CriarProduto(string message)
    {
        Task.Run(async () =>
        {
            var produto = JsonSerializer.Deserialize<Produto>(message);
            if (produto == null)
            {
                _logger.LogWarning("CriarProduto: Failed to deserialize message");
                return;
            }

            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var produtoService = scope.ServiceProvider.GetRequiredService<IProdutoService>();
                await produtoService.Post(produto);
            }

            _logger.LogInformation($"Produto criado com sucesso: {produto.Id}");
        }).ConfigureAwait(false);
    }

    private void AlterarProduto(string message)
    {
        Task.Run(async () =>
        {
            var produto = JsonSerializer.Deserialize<Produto>(message);
            if (produto == null)
            {
                _logger.LogWarning("AlterarProduto: Failed to deserialize message");
                return;
            }

            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var produtoService = scope.ServiceProvider.GetRequiredService<IProdutoService>();
                await produtoService.Put(produto); // Assuming Update is an async method
            }

            _logger.LogInformation($"Produto atualizado com sucesso: {produto.Id}");
        }).ConfigureAwait(false);
    }

    private void RemoverProduto(string message)
    {
        Task.Run(async () =>
        {
            var produto = JsonSerializer.Deserialize<Produto>(message); // Assuming the message contains the product ID
            if (produto == null)
            {
                _logger.LogWarning("RemoverProduto: Failed to deserialize message");
                return;
            }

            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var produtoService = scope.ServiceProvider.GetRequiredService<IProdutoService>();
                await produtoService.Delete(produto.Id); // Assuming Delete is an async method
            }

            _logger.LogInformation($"Produto removido com sucesso: {produto.Id}");
        }).ConfigureAwait(false);
    }

}
