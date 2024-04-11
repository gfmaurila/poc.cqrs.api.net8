using FluentValidation;
using Poc.Contract.Query.MKT.Post.Request;

namespace Poc.Contract.Query.MKT.Post.Validators;

public class GetPostByIdQueryValidator : AbstractValidator<GetPostByIdQuery>
{
    public GetPostByIdQueryValidator()
    {
        RuleFor(command => command.Id).NotEmpty();
    }
}
