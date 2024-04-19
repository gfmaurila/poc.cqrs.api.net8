namespace poc.api.redis.Model;

public class AuthEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Email { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
    public string Token { get; set; }
}

public class AuthToken
{
    public string Token { get; set; }
}