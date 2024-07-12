using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using poc.core.api.net8.Abstractions;
using Poc.Contract.Command.User.Interfaces;
using Poc.Contract.Query.User.EF.Interface;
using Poc.SQLServer.Context;
using Poc.SQLServer.Repositories;
using Poc.SQLServer.Repositories.CommandStore.User.Dapper;
using Poc.SQLServer.Repositories.CommandStore.User.EF;
using Poc.SQLServer.Repositories.QueryStore.User;


namespace Poc.SQLServer;

public class SQLServerInitializer
{
    public static void Initialize(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<EFSqlServerContext>(options => options.UseSqlServer(configuration.GetConnectionString("SqlConnection")));
        services.AddScoped(typeof(IBaseReadOnlyRepository<>), typeof(BaseReadOnlyRepository<>));
        //services.AddScoped(typeof(IBaseWriteOnlyRepository<>), typeof(BaseWriteOnlyRepository<>));

        //services.AddScoped<IUnitOfWork, UnitOfWork>();

        // CommandStore
        services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddTransient<IUserCommandStore, UserCommandStore>();
        services.AddTransient<IUserWriteOnlyRepository, UserWriteOnlyRepository>();

        // QueryStore
        services.AddTransient<IUserReadOnlyRepository, UserReadOnlyRepository>();
    }
}
