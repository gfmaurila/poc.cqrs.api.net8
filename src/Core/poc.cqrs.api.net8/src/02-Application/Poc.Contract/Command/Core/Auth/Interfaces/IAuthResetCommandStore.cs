using Poc.Contract.Command.Core.Auth.ViewModels;

namespace Poc.Contract.Command.Core.Auth.Interfaces;

public interface IAuthResetCommandStore
{
    Task<AuthResetModel> GetAuthByToken(string token);
    Task<AuthResetModel> Create(AuthResetModel entity);
    Task<AuthResetModel> Delete(string id);
    Task<AuthResetModel> GetAuthById(string id);
}