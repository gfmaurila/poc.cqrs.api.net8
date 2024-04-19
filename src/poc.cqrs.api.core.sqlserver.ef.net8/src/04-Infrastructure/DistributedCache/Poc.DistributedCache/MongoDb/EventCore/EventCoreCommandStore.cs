using MongoDB.Driver;
using Poc.Contract.Command.EventCore.Interfaces;
using Poc.Contract.Command.EventCore.ViewModels;
using Poc.DistributedCache.Configuration;

namespace Poc.DistributedCache.MongoDb.EventCore;

public class EventCoreCommandStore : IEventCoreCommandStore
{
    private readonly IMongoCollection<EventCoreModel> _model;
    public EventCoreCommandStore(MongoDatabaseFactory dbFactory)
        => _model = dbFactory.GetDatabase().GetCollection<EventCoreModel>("EventCore");
    public async Task Create(IEnumerable<EventCoreModel> entities)
        => await _model.InsertManyAsync(entities);
}
