using FluentValidation;
using Poc.Contract.Command.HR.Region.Request;

namespace Poc.Contract.Command.HR.Region.Validators;

public class CreateRegionCommandValidator : AbstractValidator<CreateRegionCommand>
{
    public CreateRegionCommandValidator()
    {
        RuleFor(command => command.RegionName)
            .NotEmpty()
            .MaximumLength(50);

    }
}
