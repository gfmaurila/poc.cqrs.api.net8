using poc.core.api.net8.Enumerado;

namespace Poc.Domain.Entities.User.DTO;

public class UpdateUserDTO
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public EGender Gender { get; set; }
    public ENotificationType Notification { get; set; }
    public DateTime DateOfBirth { get; set; }
}
