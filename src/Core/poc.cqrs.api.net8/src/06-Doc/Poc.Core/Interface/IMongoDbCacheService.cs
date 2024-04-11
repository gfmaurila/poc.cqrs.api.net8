using Poc.Core.Abstractions;

namespace Poc.Core.Interface;

public interface IMongoDbCacheService
{
    Task<IEntityMongoDb> CreateAsync(IEntityMongoDb entity, TimeSpan? ttl = null);
    Task<IEntityMongoDb> CreateAsync(IEntityMongoDb entity);
    Task<IEntityMongoDb> UpdateAsync(IEntityMongoDb entity);
    Task<bool> DeleteAsync(string id);
    Task<IEntityMongoDb> GetByIdAsync(string id);
    Task<IEnumerable<IEntityMongoDb>> GetAllAsync();
}
