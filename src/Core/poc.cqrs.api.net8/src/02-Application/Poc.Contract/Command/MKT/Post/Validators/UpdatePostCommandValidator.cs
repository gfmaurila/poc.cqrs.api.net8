using FluentValidation;
using Poc.Contract.Command.MKT.Post.Request;

namespace Poc.Contract.Command.MKT.Post.Validators;

public class UpdatePostCommandValidator : AbstractValidator<UpdatePostCommand>
{
    public UpdatePostCommandValidator()
    {
        RuleFor(command => command.Id)
            .NotEmpty();

        RuleFor(command => command.Title)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(command => command.Content)
            .NotEmpty()
            .MaximumLength(100);
    }
}
