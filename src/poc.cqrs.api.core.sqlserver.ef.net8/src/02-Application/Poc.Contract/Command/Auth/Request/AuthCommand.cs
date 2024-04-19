using Ardalis.Result;
using MediatR;
using Poc.Contract.Command.Auth.Response;
using System.ComponentModel.DataAnnotations;

namespace Poc.Contract.Command.Auth.Request;

public class AuthCommand : IRequest<Result<AuthTokenResponse>>
{
    [Required]
    [MaxLength(200)]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }
}
