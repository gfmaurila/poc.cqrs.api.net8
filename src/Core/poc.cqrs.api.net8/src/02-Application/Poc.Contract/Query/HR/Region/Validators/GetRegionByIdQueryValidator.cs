using FluentValidation;
using Poc.Contract.Query.HR.Region.Request;

namespace Poc.Contract.Query.HR.Region.Validators;

public class GetRegionByIdQueryValidator : AbstractValidator<GetRegionByIdQuery>
{
    public GetRegionByIdQueryValidator()
    {
        RuleFor(command => command.RegionId).NotEmpty();
    }
}
