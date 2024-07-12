using Ardalis.Result;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Poc.Contract.Command.Auth.Request;

public class AuthNewPasswordCommand : IRequest<Result>
{
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string ConfirmPassword { get; set; }

    [Required]
    public string Token { get; set; }
}
