using FluentValidation;
using Poc.Contract.Command.Post.Request;

namespace Poc.Contract.Command.Post.Validators;

public class DeletePostCommandValidator : AbstractValidator<DeletePostCommand>
{
    public DeletePostCommandValidator()
    {
        RuleFor(command => command.Id)
            .NotEmpty();

    }
}
