using poc.api.redis.Model;

namespace poc.api.redis.Service.Auth;

public interface IAuthQueryStore
{
    Task<AuthEntity> GetAuthByEmailPassword(string email, string passwordHash);
}
