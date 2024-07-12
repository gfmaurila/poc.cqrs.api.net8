using Ardalis.Result;
using MediatR;

namespace Poc.Contract.Command.User.Request;

public class DeleteUserCommand : IRequest<Result>
{
    public DeleteUserCommand(Guid id) => Id = id;

    public Guid Id { get; private set; }
}
