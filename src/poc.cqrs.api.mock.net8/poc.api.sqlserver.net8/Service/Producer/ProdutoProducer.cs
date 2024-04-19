using Confluent.Kafka;
using Newtonsoft.Json;
using poc.api.sqlserver.Model;

namespace poc.api.sqlserver.Service.Producer;

public class ProdutoProducer : IProdutoProducer
{
    private readonly ProducerConfig _config;
    private readonly IConfiguration _configuration;
    private readonly ILogger<ProdutoProducer> _logger;

    public ProdutoProducer(IConfiguration configuration, ILogger<ProdutoProducer> logger)
    {
        _configuration = configuration;
        _config = new ProducerConfig { BootstrapServers = _configuration["Kafka:BootstrapServers"] };
        _logger = logger;
    }

    public async Task PublishCriar(Produto model)
    {
        _logger.LogInformation($"Producer > PublishCriar > Produto > CRIAR_PRODUTO - SQL Server...");
        using var producer = new ProducerBuilder<Null, string>(_config).Build();
        var message = JsonConvert.SerializeObject(model);
        await producer.ProduceAsync(_configuration["Kafka:Topic:Produto:CriarProduto"], new Message<Null, string> { Value = message });
        producer.Flush(TimeSpan.FromSeconds(10));
    }

    public async Task PublishAlterar(Produto model)
    {
        _logger.LogInformation($"Producer > PublishAlterar > Produto > ALTERAR_PRODUTO - SQL Server...");
        using var producer = new ProducerBuilder<Null, string>(_config).Build();
        var message = JsonConvert.SerializeObject(model);
        await producer.ProduceAsync(_configuration["Kafka:Topic:Produto:AlterarProduto"], new Message<Null, string> { Value = message });
        producer.Flush(TimeSpan.FromSeconds(10));
    }

    public async Task PublishRemover(Produto model)
    {
        _logger.LogInformation($"Producer > PublishRemover > Produto > REMOVER_PRODUTO - SQL Server...");
        using var producer = new ProducerBuilder<Null, string>(_config).Build();
        var message = JsonConvert.SerializeObject(model);
        await producer.ProduceAsync(_configuration["Kafka:Topic:Produto:RemoverProduto"], new Message<Null, string> { Value = message });
        producer.Flush(TimeSpan.FromSeconds(10));
    }
}