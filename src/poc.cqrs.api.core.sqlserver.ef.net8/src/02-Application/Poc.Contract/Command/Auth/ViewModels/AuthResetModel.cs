using poc.core.api.net8.Abstractions;

namespace Poc.Contract.Command.Auth.ViewModels;

public class AuthResetModel : IEntityMongoDb
{
    public string Id { get; set; }
    public string AuthId { get; set; }
    public string EventName { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Token { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? ExpiresAt { get; set; } = DateTime.UtcNow;

}
