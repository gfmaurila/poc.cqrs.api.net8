using poc.api.redis.Model;

namespace poc.api.redis.Service.Persistence;

public interface ITwilioWhatsAppService
{
    Task<List<TwilioWhatsApp>> Get();
    Task<ResponseDefault> Post(TwilioWhatsApp entity);
    Task<TwilioWhatsApp> Delete(int id);
}
