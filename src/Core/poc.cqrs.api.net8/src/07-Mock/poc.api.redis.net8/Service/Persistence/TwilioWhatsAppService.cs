using Newtonsoft.Json;
using poc.api.redis.Model;
using StackExchange.Redis;

namespace poc.api.redis.Service.Persistence;

public class TwilioWhatsAppService : ITwilioWhatsAppService
{
    private readonly IDatabase _db;
    private readonly IConnectionMultiplexer _multiplexer;

    public TwilioWhatsAppService(IConnectionMultiplexer multiplexer)
    {
        _multiplexer = multiplexer;
        _db = multiplexer.GetDatabase();
    }

    public async Task<List<TwilioWhatsApp>> Get()
    {
        var server = _multiplexer.GetServer(_multiplexer.GetEndPoints().First());
        var keys = server.Keys(pattern: "TwilioWhatsApp:*");

        var appList = new List<TwilioWhatsApp>();

        foreach (var key in keys)
        {
            var value = await _db.StringGetAsync(key);
            if (value.HasValue)
            {
                try
                {
                    var produto = JsonConvert.DeserializeObject<TwilioWhatsApp>(value);
                    if (produto != null)
                    {
                        appList.Add(produto);
                    }
                }
                catch (JsonSerializationException ex)
                {

                }
            }
        }

        return appList;
    }

    public async Task<ResponseDefault> Post(TwilioWhatsApp entity)
    {
        if (entity is null)
        {
            return new ResponseDefault()
            {
                Success = false,
                Message = "Falha ao autenticar envio de mensagem.",
                Data = entity
            };
            //throw new ArgumentNullException(nameof(entity));
        }

        var novoId = await _db.StringIncrementAsync("TwilioWhatsApp:contador");

        entity.Id = Convert.ToInt32(novoId);
        entity.Dt = DateTime.Now;

        var key = $"TwilioWhatsApp:{entity.Id}";
        var value = JsonConvert.SerializeObject(entity);

        bool setSucess = await _db.StringSetAsync(key, value);

        if (!setSucess)
        {
            return new ResponseDefault()
            {
                Success = false,
                Message = "Falha ao salvar SendGridEmail no redis.",
                Data = entity
            };
            //throw new Exception("Falha ao salvar SendGridEmail no redis.");
        }

        return new ResponseDefault()
        {
            Success = true,
            Message = "Dados enviados com sucesso",
            Data = entity
        };
    }

    public async Task<TwilioWhatsApp> Delete(int id)
    {
        if (id != 0)
        {
            var key = $"TwilioWhatsApp:{id}";
            var value = await _db.StringGetAsync(key);

            if (!value.HasValue)
                return null;

            var entity = JsonConvert.DeserializeObject<TwilioWhatsApp>(value);
            bool deleteSucess = await _db.KeyDeleteAsync(key);

            if (!deleteSucess)
                throw new Exception("Falha ao deletar TwilioWhatsApp no redis.");

            return entity;
        }

        var getAll = await Get();

        foreach (var item in getAll)
        {
            var key = $"TwilioWhatsApp:{item.Id}";
            var value = await _db.StringGetAsync(key);

            if (!value.HasValue)
                return null;

            var entity = JsonConvert.DeserializeObject<TwilioWhatsApp>(value);
            bool deleteSucess = await _db.KeyDeleteAsync(key);

            if (!deleteSucess)
                throw new Exception("Falha ao deletar TwilioWhatsApp no redis.");
        }

        return null;
    }
}
