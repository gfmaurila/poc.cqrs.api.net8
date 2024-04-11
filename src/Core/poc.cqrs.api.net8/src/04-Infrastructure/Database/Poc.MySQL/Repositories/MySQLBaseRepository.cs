using Microsoft.EntityFrameworkCore;
using poc.core.api.net8;
using poc.core.api.net8.Abstractions;
using Poc.MySQL.Context;

namespace Poc.MySQL.Repositories;

public class MySQLBaseRepository<T> : IMySQLBaseRepository<T> where T : BaseEntity
{
    private readonly MySQLContext _concext;
    public MySQLBaseRepository(MySQLContext concext)
    {
        _concext = concext;
    }
    public virtual async Task<T> Create(T obj)
    {
        _concext.Add(obj);
        return obj;
    }

    public virtual async Task Remove(T obj)
        => _concext.Remove(obj);

    public virtual async Task<T> Update(T obj)
    {
        _concext.Entry(obj).State = EntityState.Modified;
        return obj;
    }

    public virtual async Task<T> Get(Guid id)
    {
        var obj = await _concext.Set<T>().AsNoTracking().Where(f => f.Id == id).ToListAsync();
        return obj.FirstOrDefault();
    }

    public virtual async Task<List<T>> Get()
        => await _concext.Set<T>().AsNoTracking().ToListAsync();
}
