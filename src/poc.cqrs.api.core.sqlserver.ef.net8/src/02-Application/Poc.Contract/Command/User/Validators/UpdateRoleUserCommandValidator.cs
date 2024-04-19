using FluentValidation;
using Poc.Contract.Command.User.Request;

namespace Poc.Contract.Command.User.Validators;

public class UpdateRoleUserCommandValidator : AbstractValidator<UpdateRoleUserCommand>
{
    public UpdateRoleUserCommandValidator()
    {
    }
}
