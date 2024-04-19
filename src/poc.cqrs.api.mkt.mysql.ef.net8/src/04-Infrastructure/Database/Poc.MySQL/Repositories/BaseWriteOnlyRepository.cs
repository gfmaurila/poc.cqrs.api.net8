using Microsoft.EntityFrameworkCore;
using poc.core.api.net8;
using poc.core.api.net8.Abstractions;
using Poc.MySQL.Context;

namespace Poc.MySQL.Repositories;

public class BaseWriteOnlyRepository<T> : IBaseWriteOnlyRepository<T> where T : BaseEntity
{
    private readonly MySQLContext _context;

    public BaseWriteOnlyRepository(MySQLContext context)
    {
        _context = context;
    }

    public virtual async Task<T> Create(T obj)
    {
        _context.Add(obj);
        await _context.SaveChangesAsync();

        return obj;
    }

    public virtual async Task<T> Update(T obj)
    {
        _context.Entry(obj).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return obj;
    }

    public virtual async Task Remove(T obj)
    {
        _context.Remove(obj);
        await _context.SaveChangesAsync();
    }
}
