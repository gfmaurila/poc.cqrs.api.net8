using poc.api.redis.Model;

namespace poc.api.redis.Service.Auth;

public interface IAuthService
{
    Task<AuthToken> Auth(AuthRequest request);
}
