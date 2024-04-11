using FluentValidation;
using Poc.Contract.Command.HR.Region.Request;

namespace Poc.Contract.Command.HR.Region.Validators;

public class DeleteRegionCommandValidator : AbstractValidator<DeleteRegionCommand>
{
    public DeleteRegionCommandValidator()
    {
        RuleFor(command => command.RegionId)
            .NotEmpty();
    }
}
