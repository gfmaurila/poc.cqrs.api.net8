
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Poc.Contract.Command.Auth.ViewModels;

public class AuthTokenModel
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    public string Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Token { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
