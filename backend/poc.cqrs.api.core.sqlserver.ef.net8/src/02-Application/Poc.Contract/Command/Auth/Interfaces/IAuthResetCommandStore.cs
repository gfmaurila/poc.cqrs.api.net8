using Poc.Contract.Command.Auth.ViewModels;

namespace Poc.Contract.Command.Auth.Interfaces;

public interface IAuthResetCommandStore
{
    Task<AuthResetModel> GetAuthByToken(string token);
    Task<AuthResetModel> Create(AuthResetModel entity);
    Task<AuthResetModel> Delete(string id);
    Task<AuthResetModel> GetAuthById(string id);
}