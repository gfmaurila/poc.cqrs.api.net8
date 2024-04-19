using Ardalis.Result;
using MediatR;
using poc.core.api.net8.Enumerado;
using Poc.Contract.Command.User.Response;
using System.ComponentModel.DataAnnotations;

namespace Poc.Contract.Command.User.Request;

public class CreateUserCommand : IRequest<Result<CreateUserResponse>>
{
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
    public ENotificationType Notification { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime DateOfBirth { get; set; }

    [Required]
    [MaxLength(200)]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }

    [Required]
    [MaxLength(20)]
    [DataType(DataType.PhoneNumber)]
    public string Phone { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string ConfirmPassword { get; set; }

    public List<string> RoleUserAuth { get; set; } = new List<string>();
}
