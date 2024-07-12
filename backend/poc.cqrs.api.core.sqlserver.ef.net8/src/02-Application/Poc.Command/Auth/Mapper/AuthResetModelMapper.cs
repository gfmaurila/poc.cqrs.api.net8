using Poc.Contract.Command.Auth.ViewModels;
using Poc.Domain.Entities.User.Events.Auth;

namespace Poc.Command.Auth.Mapper;

public static class AuthResetModelMapper
{
    public static AuthResetModel MapEvetToModel(AuthResetEvent authevent, string token)
    {
        return new AuthResetModel()
        {
            AuthId = authevent.Id.ToString(),
            Nome = authevent.FirstName,
            Email = authevent.Email,
            Token = token,
            CreatedAt = DateTime.Now,
        };
    }

    public static AuthResetModel MapEvetToCache(AuthResetEvent authevent, string token)
    {
        return new AuthResetModel()
        {
            AuthId = authevent.Id.ToString(),
            Nome = authevent.FirstName,
            Email = authevent.Email,
            Token = token,
            CreatedAt = DateTime.UtcNow
        };
    }
}
