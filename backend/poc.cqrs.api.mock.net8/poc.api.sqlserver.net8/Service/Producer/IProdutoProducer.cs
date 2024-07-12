using poc.api.sqlserver.Model;

namespace poc.api.sqlserver.Service.Producer;

public interface IProdutoProducer
{
    Task PublishCriar(Produto model);
    Task PublishAlterar(Produto model);
    Task PublishRemover(Produto model);
}