using Ardalis.Result;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Poc.Contract.Command.Auth.Request;

public class AuthResetPasswordCommand : IRequest<Result>
{
    [Required]
    [MaxLength(200)]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }
}
