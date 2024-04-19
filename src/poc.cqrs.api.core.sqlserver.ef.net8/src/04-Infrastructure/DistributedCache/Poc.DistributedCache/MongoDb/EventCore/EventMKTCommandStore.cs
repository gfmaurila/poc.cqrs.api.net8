using MongoDB.Driver;
using Poc.Contract.Command.EventCore.Interfaces;
using Poc.Contract.Command.EventCore.ViewModels;
using Poc.DistributedCache.Configuration;

namespace Poc.DistributedCache.MongoDb.EventCore;

public class EventMKTCommandStore : IEventMKTCommandStore
{
    private readonly IMongoCollection<EventMKTModel> _model;
    public EventMKTCommandStore(MongoDatabaseFactory dbFactory)
        => _model = dbFactory.GetDatabase().GetCollection<EventMKTModel>("EventMKT");
    public async Task Create(IEnumerable<EventMKTModel> entities)
        => await _model.InsertManyAsync(entities);
}
