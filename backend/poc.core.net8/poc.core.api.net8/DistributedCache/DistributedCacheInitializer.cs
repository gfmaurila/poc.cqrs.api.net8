using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using poc.core.api.net8.AppSettings;
using poc.core.api.net8.DistributedCache.Configuration;
using poc.core.api.net8.DistributedCache.Redis;
using poc.core.api.net8.Interface;
using StackExchange.Redis;

namespace poc.core.api.net8.DistributedCache;

public class DistributedCacheInitializer
{
    public static void Initialize(IServiceCollection services, IConfiguration configuration)
    {

        //var settings = configuration.GetSection("MongoDB").Get<MongoDbSettings>();
        //services.AddSingleton(settings);
        //services.AddSingleton<IMongoClient, MongoClient>(sp => new MongoClient(settings.ConnectionString));
        //services.AddScoped(sp => new MongoDatabaseFactory(sp.GetRequiredService<IMongoClient>(), settings.Database));
        //services.AddScoped(sp => sp.GetRequiredService<MongoDatabaseFactory>().GetDatabase());



        // Auth
        services.AddSingleton<IConfiguration>(provider => configuration);
        services.AddSingleton<RedisConnection>();

        services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect(configuration.GetConnectionString("CacheConnection")));
        services.AddScoped(typeof(IRedisCacheService<>), typeof(RedisCacheService<>));
        services.Configure<CacheOptions>(configuration.GetSection("CacheOptions"));


        // Generica
        //services.AddTransient<IMongoDbCacheService, MongoDbCacheService>();
        //services.AddTransient<IDomainEventDistributedCacheService, DomainEventDistributedCacheService>();
        //services.AddTransient<IEventCoreCommandStore, EventCoreCommandStore>();
        //services.AddTransient<IEventMKTCommandStore, EventMKTCommandStore>();

        //services.AddTransient<IAuthTokenCommandStore, AuthTokenCommandStore>();
        //services.AddTransient<IAuthResetCommandStore, AuthResetCommandStore>();
    }

}
