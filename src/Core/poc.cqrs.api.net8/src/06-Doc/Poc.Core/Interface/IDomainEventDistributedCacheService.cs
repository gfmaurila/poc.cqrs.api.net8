using Poc.Core.Model;

namespace Poc.Core.Interface;

public interface IDomainEventDistributedCacheService
{
    Task<DomainEventDistributedCache> Create(DomainEventDistributedCache entity);
    Task<DomainEventDistributedCache> Update(DomainEventDistributedCache entity);
    Task<DomainEventDistributedCache> Delete(string id);
    Task<DomainEventDistributedCache> Get(string id);
    Task<List<DomainEventDistributedCache>> Get();
}
