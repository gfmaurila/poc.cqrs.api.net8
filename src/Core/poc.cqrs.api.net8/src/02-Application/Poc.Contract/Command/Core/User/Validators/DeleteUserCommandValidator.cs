using FluentValidation;
using Poc.Contract.Command.Core.User.Request;

namespace Poc.Contract.Command.Core.User.Validators;

public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
{
    public DeleteUserCommandValidator()
    {
        RuleFor(command => command.Id)
            .NotEmpty();

    }
}
