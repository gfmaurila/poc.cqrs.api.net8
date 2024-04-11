namespace Poc.Core.Abstractions;

public interface IMySQLBaseReadOnlyRepository<T> where T : BaseEntity
{
    Task<T> Get(Guid id);
    Task<List<T>> Get();
}
