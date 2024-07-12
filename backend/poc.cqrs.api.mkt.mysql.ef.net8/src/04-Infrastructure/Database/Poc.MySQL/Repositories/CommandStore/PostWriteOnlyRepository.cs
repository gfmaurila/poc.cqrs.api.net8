using Microsoft.EntityFrameworkCore;
using Poc.Contract.Command.Post.Interfaces;
using Poc.Domain.Entities.Post;
using Poc.MySQL.Context;

namespace Poc.MySQL.Repositories.CommandStore;

public class PostWriteOnlyRepository : BaseRepository<PostEntity>, IPostWriteOnlyRepository
{
    private readonly MySQLContext _context;
    public PostWriteOnlyRepository(MySQLContext context) : base(context)
    {
        _context = context;
    }

    public async Task<bool> ExistsByTitleAsync(string title)
        => await _context.Post.AsNoTracking().AnyAsync(entity => entity.Title == title);
}
