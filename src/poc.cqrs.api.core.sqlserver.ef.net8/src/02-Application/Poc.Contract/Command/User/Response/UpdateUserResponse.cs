using Ardalis.Result;
using MediatR;
using poc.core.api.net8.Enumerado;
using System.ComponentModel.DataAnnotations;

namespace Poc.Contract.Command.User.Response;

public class UpdateUserResponse : IRequest<Result>
{
    [Required]
    public Guid Id { get; set; }

    [Required]
    [MaxLength(100)]
    [DataType(DataType.Text)]
    public string FirstName { get; set; }

    [Required]
    [MaxLength(100)]
    [DataType(DataType.Text)]
    public string LastName { get; set; }

    [Required]
    public EGender Gender { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime DateOfBirth { get; set; }
}
