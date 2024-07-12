using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using poc.core.api.net8.Events;

namespace Poc.Contract.Command.EventCore.ViewModels;
public class EventMKTModel : Event
{
    public EventMKTModel(Guid aggregateId, string messageType, string data)
    {
        AggregateId = aggregateId;
        MessageType = messageType;
        Data = data;
        CreatedAt = DateTime.UtcNow;
    }

    [BsonId]
    [BsonRepresentation(BsonType.String)]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Data { get; private init; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}

