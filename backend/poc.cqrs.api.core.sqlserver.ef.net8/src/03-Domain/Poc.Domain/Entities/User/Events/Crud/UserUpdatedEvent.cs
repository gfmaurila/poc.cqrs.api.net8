using poc.core.api.net8.Enumerado;

namespace Poc.Domain.Entities.User.Events.Crud;

/// <summary>
/// Evento que representa uma atualização de um entidade.
/// </summary>
public class UserUpdatedEvent : UserBaseEvent
{
    public UserUpdatedEvent(Guid id, string firstName, string lastName, EGender gender, ENotificationType notification, string email, string phone, string password, List<string> role, DateTime dateOfBirth) :
                       base(id, firstName, lastName, gender, notification, email, phone, password, role, dateOfBirth)
    {
    }
}
