using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using poc.core.api.net8;
using poc.core.api.net8.Abstractions;
using Poc.SQLServer.Context;

namespace Poc.SQLServer.Repositories;

public class BaseReadOnlyRepository<T> : IBaseReadOnlyRepository<T> where T : BaseEntity
{
    private readonly EFSqlServerContext _context;

    public BaseReadOnlyRepository(EFSqlServerContext context)
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
