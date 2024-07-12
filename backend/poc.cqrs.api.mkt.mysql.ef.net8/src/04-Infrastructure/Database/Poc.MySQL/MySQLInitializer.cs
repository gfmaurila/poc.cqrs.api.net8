using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using poc.core.api.net8.Abstractions;
using Poc.Contract.Command.Post.Interfaces;
using Poc.Contract.Query.Post.Interface;
using Poc.MySQL.Context;
using Poc.MySQL.Repositories;
using Poc.MySQL.Repositories.CommandStore;
using Poc.MySQL.Repositories.QueryStore;

namespace Poc.MySQL;

public class MySQLInitializer
{
    public static void Initialize(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<MySQLContext>(options => options.UseMySQL(configuration.GetConnectionString("MySqlConnection")));
        services.AddScoped(typeof(IBaseReadOnlyRepository<>), typeof(BaseReadOnlyRepository<>));
        services.AddScoped(typeof(IBaseWriteOnlyRepository<>), typeof(BaseWriteOnlyRepository<>));

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

        // CommandStore
        services.AddTransient<IPostWriteOnlyRepository, PostWriteOnlyRepository>();

        // QueryStore
        services.AddTransient<IPostReadOnlyRepository, PostReadOnlyRepository>();
    }
}
