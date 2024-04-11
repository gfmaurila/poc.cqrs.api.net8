using Ardalis.Result;
using MediatR;
using Poc.Contract.Query.MKT.Post.QueriesModel;

namespace Poc.Contract.Query.MKT.Post.Request;

public class GetPostByIdQuery : IRequest<Result<PostQueryModel>>
{
    public GetPostByIdQuery(Guid id)
    {
        Id = id;
    }
    public Guid Id { get; private set; }
}
