using FluentValidation;
using Poc.Contract.Command.Core.User.Request;

namespace Poc.Contract.Command.Core.User.Validators;

public class UpdateRoleUserCommandValidator : AbstractValidator<UpdateRoleUserCommand>
{
    public UpdateRoleUserCommandValidator()
    {
    }
}
