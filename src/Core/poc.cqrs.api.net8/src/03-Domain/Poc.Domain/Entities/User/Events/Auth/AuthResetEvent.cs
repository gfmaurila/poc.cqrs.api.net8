using poc.core.api.net8.Enumerado;

namespace Poc.Domain.Entities.User.Events.Auth;

public class AuthResetEvent : UserBaseEvent
{
    public AuthResetEvent(Guid id, string firstName, string lastName, EGender gender, ENotificationType notification, string email, string phone, string password, List<string> role, DateTime dateOfBirth) :
                       base(id, firstName, lastName, gender, notification, email, phone, password, role, dateOfBirth)
    {
    }
}
