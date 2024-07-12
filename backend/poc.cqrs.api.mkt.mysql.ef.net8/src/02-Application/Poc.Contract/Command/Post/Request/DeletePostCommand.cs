using Ardalis.Result;
using MediatR;

namespace Poc.Contract.Command.Post.Request;

public class DeletePostCommand : IRequest<Result>
{
    public DeletePostCommand(Guid id) => Id = id;

    public Guid Id { get; private set; }
}
