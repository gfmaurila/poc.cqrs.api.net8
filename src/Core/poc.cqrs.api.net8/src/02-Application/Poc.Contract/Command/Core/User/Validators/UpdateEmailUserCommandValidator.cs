using FluentValidation;
using Poc.Contract.Command.Core.User.Request;

namespace Poc.Contract.Command.Core.User.Validators;

public class UpdateEmailUserCommandValidator : AbstractValidator<UpdateEmailUserCommand>
{
    public UpdateEmailUserCommandValidator()
    {
        RuleFor(command => command.Id)
            .NotEmpty();

        RuleFor(command => command.Email)
            .NotEmpty()
            .MaximumLength(254)
            .EmailAddress();

    }
}
