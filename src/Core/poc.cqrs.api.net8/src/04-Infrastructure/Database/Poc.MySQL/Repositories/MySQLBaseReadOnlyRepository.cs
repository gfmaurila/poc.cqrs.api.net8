using Microsoft.EntityFrameworkCore;
using poc.core.api.net8;
using poc.core.api.net8.Abstractions;
using Poc.MySQL.Context;

namespace Poc.MySQL.Repositories;

public class MySQLBaseReadOnlyRepository<T> : IMySQLBaseReadOnlyRepository<T> where T : BaseEntity
{
    private readonly MySQLContext _context;

    public MySQLBaseReadOnlyRepository(MySQLContext context)
    {
        _context = context;
    }

    public virtual async Task<T> Get(Guid id)
    {
        var obj = await _context.Set<T>()
                                .AsNoTracking()
                                .Where(x => x.Id == id)
                                .ToListAsync();

        return obj.FirstOrDefault();
    }

    public virtual async Task<List<T>> Get()
    {
        return await _context.Set<T>()
                             .AsNoTracking()
                             .ToListAsync();
    }
}
