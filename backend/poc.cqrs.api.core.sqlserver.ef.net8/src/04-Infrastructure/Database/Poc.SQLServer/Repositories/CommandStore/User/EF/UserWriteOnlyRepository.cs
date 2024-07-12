using Microsoft.EntityFrameworkCore;
using poc.core.api.net8.ValueObjects;
using Poc.Contract.Command.User.Interfaces;
using Poc.Domain.Entities.User;
using Poc.SQLServer.Context;

namespace Poc.SQLServer.Repositories.CommandStore.User.EF;

public class UserWriteOnlyRepository : BaseRepository<UserEntity>, IUserWriteOnlyRepository
{
    private readonly EFSqlServerContext _context;
    public UserWriteOnlyRepository(EFSqlServerContext context) : base(context)
    {
        _context = context;
    }

    public async Task<bool> ExistsByEmailAsync(Email email)
        => await _context.User.AsNoTracking().AnyAsync(entity => entity.Email.Address == email.Address);

    public async Task<bool> ExistsByEmailAsync(Email email, Guid currentId)
        => await _context.User.AsNoTracking().AnyAsync(entity => entity.Email.Address == email.Address && entity.Id != currentId);
}
