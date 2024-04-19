namespace poc.core.api.net8.Abstractions;

public interface IMySQLBaseWriteOnlyRepository<T> where T : BaseEntity
{
    Task<T> Create(T obj);
    Task<T> Update(T obj);
    Task Remove(T obj);
}
