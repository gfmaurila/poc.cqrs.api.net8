using Ardalis.Result;
using MediatR;

namespace Poc.Contract.Command.Core.User.Request;

public class DeleteUserCommand : IRequest<Result>
{
    public DeleteUserCommand(Guid id) => Id = id;

    public Guid Id { get; private set; }
}
