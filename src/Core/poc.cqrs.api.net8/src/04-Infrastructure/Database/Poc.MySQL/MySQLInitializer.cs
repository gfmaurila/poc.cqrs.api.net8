using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using poc.core.api.net8.Abstractions;
using Poc.Contract.Command.MKT.Post.Interfaces;
using Poc.Contract.Query.MKT.Post.Interface;
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
        services.AddScoped(typeof(IMySQLBaseReadOnlyRepository<>), typeof(MySQLBaseReadOnlyRepository<>));
        services.AddScoped(typeof(IMySQLBaseWriteOnlyRepository<>), typeof(MySQLBaseWriteOnlyRepository<>));

        services.AddScoped<IMySQLUnitOfWork, MySQLUnitOfWork>();
        services.AddScoped(typeof(IMySQLBaseRepository<>), typeof(MySQLBaseRepository<>));

        // CommandStore
        services.AddTransient<IPostWriteOnlyRepository, PostWriteOnlyRepository>();

        // QueryStore
        services.AddTransient<IPostReadOnlyRepository, PostReadOnlyRepository>();
    }
}
