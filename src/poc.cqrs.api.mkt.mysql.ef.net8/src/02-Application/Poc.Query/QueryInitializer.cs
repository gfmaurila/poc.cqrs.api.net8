using Ardalis.Result;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Poc.Contract.Query.Post.QueriesModel;
using Poc.Contract.Query.Post.Request;
using Poc.Contract.Query.Post.Validators;
using Poc.Query.Post;

namespace Poc.Query;

public class QueryInitializer
{
    public static void Initialize(IServiceCollection services)
    {
        #region MySQL
        services.AddTransient<IRequestHandler<GetPostQuery, Result<List<PostQueryModel>>>, GetPostQueryHandler>();
        services.AddTransient<IRequestHandler<GetPostByIdQuery, Result<PostQueryModel>>, GetPostByIdQueryHandler>();
        services.AddTransient<GetPostByIdQueryValidator>();
        #endregion

    }
}
