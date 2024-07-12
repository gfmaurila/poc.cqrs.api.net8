using poc.api.redis.Model;

namespace poc.api.redis.Service.Persistence;

public interface ISendGridEmailService
{
    Task<List<SendGridEmail>> Get();
    Task<ResponseDefault> Post(SendGridEmail entity);
    Task<SendGridEmail> Delete(int id);
}
