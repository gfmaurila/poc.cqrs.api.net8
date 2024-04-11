using Poc.Contract.Command.Core.Auth.ViewModels;

namespace Poc.Contract.Command.Core.Auth.Interfaces;

public interface IAuthTokenCommandStore
{
    Task<AuthTokenModel> GetAuthByToken(string token);
    Task<AuthTokenModel> Create(AuthTokenModel entity);
    Task<AuthTokenModel> Delete(string id);
    Task<AuthTokenModel> GetAuthById(string id);
}
