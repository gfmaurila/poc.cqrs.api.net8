using Ardalis.Result;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Poc.Contract.Query.User.EF.QueriesModel;
using Poc.Contract.Query.User.Request;
using Poc.Contract.Query.User.Validators;
using Poc.Query.User;

namespace Poc.Query;

public class QueryInitializer
{
    public static void Initialize(IServiceCollection services)
    {
        #region SqlServer
        services.AddTransient<IRequestHandler<GetUserByIdQuery, Result<UserQueryModel>>, GetUserByIdQueryHandler>();
        services.AddTransient<IRequestHandler<GetUserQuery, Result<List<UserQueryModel>>>, GetUserQueryHandler>();
        services.AddTransient<GetUserByIdQueryValidator>();
        #endregion
    }
}
