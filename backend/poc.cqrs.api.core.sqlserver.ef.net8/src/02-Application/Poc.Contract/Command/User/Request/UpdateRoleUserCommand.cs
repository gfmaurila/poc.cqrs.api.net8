using Ardalis.Result;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Poc.Contract.Command.User.Request;

public class UpdateRoleUserCommand : IRequest<Result>
{
    [Required]
    public Guid Id { get; set; }

    public List<string> RoleUserAuth { get; set; } = new List<string>();
}
