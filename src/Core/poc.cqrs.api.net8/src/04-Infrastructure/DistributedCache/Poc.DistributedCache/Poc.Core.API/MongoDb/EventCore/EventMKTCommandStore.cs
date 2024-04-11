using MongoDB.Driver;
using Poc.Contract.Command.Core.EventCore.Interfaces;
using Poc.Contract.Command.Core.EventCore.ViewModels;
using Poc.DistributedCache.Poc.Core.API.Configuration;

namespace Poc.DistributedCache.Poc.Core.API.MongoDb.EventCore;

public class EventMKTCommandStore : IEventMKTCommandStore
{
    private readonly IMongoCollection<EventMKTModel> _model;
    public EventMKTCommandStore(MongoDatabaseFactory dbFactory)
        => _model = dbFactory.GetDatabase().GetCollection<EventMKTModel>("EventMKT");
    public async Task Create(IEnumerable<EventMKTModel> entities)
        => await _model.InsertManyAsync(entities);
}
