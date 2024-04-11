namespace Poc.Core.Abstractions;

public interface IMySQLUnitOfWork : IDisposable
{
    Task SaveChangesAsync();
}
