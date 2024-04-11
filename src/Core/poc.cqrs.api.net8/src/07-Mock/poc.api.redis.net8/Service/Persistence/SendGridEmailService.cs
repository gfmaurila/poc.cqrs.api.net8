using Newtonsoft.Json;
using poc.api.redis.Model;
using StackExchange.Redis;

namespace poc.api.redis.Service.Persistence;

public class SendGridEmailService : ISendGridEmailService
{
    private readonly IDatabase _db;
    private readonly IConnectionMultiplexer _multiplexer;

    public SendGridEmailService(IConnectionMultiplexer multiplexer)
    {
        _multiplexer = multiplexer;
        _db = multiplexer.GetDatabase();
    }

    public async Task<List<SendGridEmail>> Get()
    {
        var server = _multiplexer.GetServer(_multiplexer.GetEndPoints().First());
        var keys = server.Keys(pattern: "SendGridEmail:*");

        var appList = new List<SendGridEmail>();

        foreach (var key in keys)
        {
            var value = await _db.StringGetAsync(key);
            if (value.HasValue)
            {
                try
                {
                    var produto = JsonConvert.DeserializeObject<SendGridEmail>(value);
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

    public async Task<ResponseDefault> Post(SendGridEmail entity)
    {
        if (entity is null)
        {
            return new ResponseDefault()
            {
                Success = false,
                Message = "Falha ao autenticar envio de email.",
                Data = entity
            };
            //throw new ArgumentNullException(nameof(entity));
        }

        var novoId = await _db.StringIncrementAsync("SendGridEmail:contador");

        entity.Id = Convert.ToInt32(novoId);
        entity.Dt = DateTime.Now;

        var key = $"SendGridEmail:{entity.Id}";
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

    public async Task<SendGridEmail> Delete(int id)
    {
        //var key = $"SendGridEmail:{id}";
        //var value = await _db.StringGetAsync(key);

        //if (!value.HasValue)
        //    return null;

        //var entity = JsonConvert.DeserializeObject<SendGridEmail>(value);
        //bool deleteSucess = await _db.KeyDeleteAsync(key);

        //if (!deleteSucess)
        //    throw new Exception("Falha ao deletar SendGridEmail no redis.");

        //return entity;




        if (id != 0)
        {
            var key = $"SendGridEmail:{id}";
            var value = await _db.StringGetAsync(key);

            if (!value.HasValue)
                return null;

            var entity = JsonConvert.DeserializeObject<SendGridEmail>(value);
            bool deleteSucess = await _db.KeyDeleteAsync(key);

            if (!deleteSucess)
                throw new Exception("Falha ao deletar SendGridEmail no redis.");

            return entity;
        }

        var getAll = await Get();

        foreach (var item in getAll)
        {
            var key = $"SendGridEmail:{item.Id}";
            var value = await _db.StringGetAsync(key);

            if (!value.HasValue)
                return null;

            var entity = JsonConvert.DeserializeObject<SendGridEmail>(value);
            bool deleteSucess = await _db.KeyDeleteAsync(key);

            if (!deleteSucess)
                throw new Exception("Falha ao deletar SendGridEmail no redis.");
        }

        return null;
    }
}
