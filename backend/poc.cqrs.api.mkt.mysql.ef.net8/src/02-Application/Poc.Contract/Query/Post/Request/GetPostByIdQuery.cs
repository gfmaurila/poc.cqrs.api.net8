using Ardalis.Result;
using MediatR;
using Poc.Contract.Query.Post.QueriesModel;

namespace Poc.Contract.Query.Post.Request;

public class GetPostByIdQuery : IRequest<Result<PostQueryModel>>
{
    public GetPostByIdQuery(Guid id)
    {
        Id = id;
    }
    public Guid Id { get; private set; }
}
