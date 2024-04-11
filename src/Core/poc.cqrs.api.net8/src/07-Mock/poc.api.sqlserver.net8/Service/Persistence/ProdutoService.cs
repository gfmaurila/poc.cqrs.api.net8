using Microsoft.EntityFrameworkCore;
using poc.api.sqlserver.Configuration;
using poc.api.sqlserver.Model;
using poc.api.sqlserver.Service.Producer;

namespace poc.api.sqlserver.Service.Persistence;

public class ProdutoService : IProdutoService
{
    private readonly SqlServerDb _db;
    private readonly IProdutoProducer _producer;

    public ProdutoService(SqlServerDb db, IProdutoProducer producer)
    {
        _db = db;
        _producer = producer;
    }

    public async Task<List<Produto>> Get()
        => await _db.Produto.AsNoTracking().ToListAsync();

    public async Task<Produto> Get(int id)
        => await _db.Produto.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

    public async Task<Produto> Post(Produto entity)
    {
        if (entity is null)
            throw new ArgumentNullException(nameof(entity));

        await _db.Produto.AddAsync(entity);
        await _db.SaveChangesAsync();

        await _producer.PublishCriar(entity);

        return entity;
    }

    public async Task<Produto> Put(Produto entity)
    {
        if (entity is null)
            throw new ArgumentNullException(nameof(entity));

        _db.Produto.Update(entity);
        await _db.SaveChangesAsync();

        await _producer.PublishAlterar(entity);

        return entity;
    }

    public async Task<Produto> Delete(int id)
    {
        var entity = await Get(id);

        if (entity is null)
            throw new ArgumentNullException(nameof(entity));

        _db.Produto.Remove(entity);
        await _db.SaveChangesAsync();

        await _producer.PublishRemover(entity);

        return entity;
    }
}
