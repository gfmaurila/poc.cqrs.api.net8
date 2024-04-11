using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Poc.Core.Model;

public class DomainEventDistributedCache
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public BsonDocument Events { get; set; }
}
