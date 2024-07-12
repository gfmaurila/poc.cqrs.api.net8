using poc.core.api.net8.Abstractions;
using poc.core.api.net8.ValueObjects;
using Poc.Domain.Entities.User;

namespace Poc.Contract.Command.User.Interfaces;

public interface IUserWriteOnlyRepository : IBaseRepository<UserEntity>
{
    Task<bool> ExistsByEmailAsync(Email email);
    Task<bool> ExistsByEmailAsync(Email email, Guid currentId);
}
