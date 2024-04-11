using FluentValidation;
using Poc.Contract.Command.MKT.Post.Request;

namespace Poc.Contract.Command.MKT.Post.Validators;

public class DeletePostCommandValidator : AbstractValidator<DeletePostCommand>
{
    public DeletePostCommandValidator()
    {
        RuleFor(command => command.Id)
            .NotEmpty();

    }
}
