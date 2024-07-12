namespace poc.core.api.net8.Abstractions;

public interface IMySQLUnitOfWork : IDisposable
{
    Task SaveChangesAsync();
}
