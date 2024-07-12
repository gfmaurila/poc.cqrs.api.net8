using FluentValidation;
using Poc.Contract.Command.User.Request;

namespace Poc.Contract.Command.User.Validators;

public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
{
    public DeleteUserCommandValidator()
    {
        RuleFor(command => command.Id)
            .NotEmpty();

    }
}
