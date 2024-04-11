using FluentValidation;
using Poc.Contract.Command.HR.Region.Request;

namespace Poc.Contract.Command.HR.Region.Validators;

public class UpdateRegionCommandValidator : AbstractValidator<UpdateRegionCommand>
{
    public UpdateRegionCommandValidator()
    {
        RuleFor(command => command.RegionId)
            .NotEmpty();

        RuleFor(command => command.RegionName)
            .NotEmpty()
            .MaximumLength(50);

    }
}
