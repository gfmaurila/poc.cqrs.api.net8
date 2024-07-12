using FluentValidation;
using Poc.Contract.Query.Post.Request;

namespace Poc.Contract.Query.Post.Validators;

public class GetPostByIdQueryValidator : AbstractValidator<GetPostByIdQuery>
{
    public GetPostByIdQueryValidator()
    {
        RuleFor(command => command.Id).NotEmpty();
    }
}
