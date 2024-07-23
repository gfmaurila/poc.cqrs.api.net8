using Microsoft.Extensions.Options;
using poc.core.api.net8.AppSettings;
using poc.core.api.net8.DistributedCache.Configuration;
using poc.core.api.net8.Interface;
using StackExchange.Redis;
using System.Text.Json;

namespace poc.core.api.net8.DistributedCache.Redis;

public class RedisCacheService<T> : IRedisCacheService<T>
{
    private readonly IDatabase _database;
    private readonly CacheOptions _cacheOptions;

    public RedisCacheService(RedisConnection redisConnection, IOptions<CacheOptions> cacheOptions)
    {
        _cacheOptions = cacheOptions.Value;
        // Aqui você passa o índice do banco de dados definido nas configurações para o método GetDatabase
        _database = redisConnection.GetDatabase(_cacheOptions.DbIndex);
    }

    public async Task<bool> SetAsync(string key, T value, TimeSpan? expiry = null)
    {
        var serializedValue = JsonSerializer.Serialize(value);
        return await _database.StringSetAsync(key, serializedValue, expiry);
    }

    public async Task<long> AddToListAsync(string listKey, T value)
    {
        var serializedValue = JsonSerializer.Serialize(value);
        return await _database.ListRightPushAsync(listKey, serializedValue);
    }

    public async Task<T> GetOrCreateAsync(string key, Func<Task<T>> createItem, TimeSpan? expiry = null)
    {
        var value = await _database.StringGetAsync(key);
        if (!value.IsNullOrEmpty)
            return JsonSerializer.Deserialize<T>(value);

        var newValue = await createItem();

        var serializedValue = JsonSerializer.Serialize(newValue);
        await _database.StringSetAsync(key, serializedValue, expiry);

        return newValue;
    }

    public async Task<IEnumerable<T>> GetListAsync(string listKey)
    {
        var values = await _database.ListRangeAsync(listKey);
        return values.Select(value => JsonSerializer.Deserialize<T>(value)).Where(item => item != null);
    }

    public async Task<long> RemoveFromListAsync(string listKey, T value)
    {
        var serializedValue = JsonSerializer.Serialize(value);
        return await _database.ListRemoveAsync(listKey, serializedValue);
    }

    public async Task<T> GetAsync(string key)
    {
        var value = await _database.StringGetAsync(key);
        if (value.IsNullOrEmpty) return default;

        return JsonSerializer.Deserialize<T>(value);
    }

    public async Task<bool> DeleteAsync(string key)
    {
        return await _database.KeyDeleteAsync(key);
    }
}
