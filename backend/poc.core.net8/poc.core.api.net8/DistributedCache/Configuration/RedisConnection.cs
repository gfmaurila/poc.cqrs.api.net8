using Microsoft.Extensions.Configuration;
using StackExchange.Redis;

namespace poc.core.api.net8.DistributedCache.Configuration;

public class RedisConnection
{
    private static ConnectionMultiplexer _redisConnection;
    private static readonly object padlock = new object();

    public RedisConnection(IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("CacheConnection");
        lock (padlock)
        {
            if (_redisConnection == null || !_redisConnection.IsConnected)
            {
                _redisConnection = ConnectionMultiplexer.Connect(connectionString);
            }
        }
    }

    public IDatabase GetDatabase()
    {
        return _redisConnection.GetDatabase();
    }
}