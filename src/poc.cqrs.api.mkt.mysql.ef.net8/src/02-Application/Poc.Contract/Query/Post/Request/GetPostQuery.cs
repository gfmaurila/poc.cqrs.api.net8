using Ardalis.Result;
using MediatR;
using Poc.Contract.Query.Post.QueriesModel;

namespace Poc.Contract.Query.Post.Request;

public class GetPostQuery : IRequest<Result<List<PostQueryModel>>>
{
    public GetPostQuery()
    {
    }
}
