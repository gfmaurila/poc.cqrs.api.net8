using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Poc.Contract.Query.Post.Interface;
using Poc.Contract.Query.Post.QueriesModel;
using Poc.MySQL.Context;

namespace Poc.MySQL.Repositories.QueryStore;

public class PostReadOnlyRepository : IPostReadOnlyRepository
{
    private readonly MySQLContext _db;
    private readonly IMapper _mapper;
    public PostReadOnlyRepository(MySQLContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<List<PostQueryModel>> Get()
        => _mapper.Map<List<PostQueryModel>>(await _db.Post.AsNoTracking().ToListAsync());

    public async Task<PostQueryModel> Get(Guid id)
    {
        var entity = await _db.Post.AsNoTracking()
                                   .Where(u => u.Id == id)
                                   .FirstOrDefaultAsync();

        var model = _mapper.Map<PostQueryModel>(entity);

        return model;
    }

    public async Task<PostQueryModel> GetByTitle(string title)
    {
        var entity = await _db.Post.AsNoTracking()
                                   .Where(u => u.Title == title)
                                   .FirstOrDefaultAsync();

        var model = _mapper.Map<PostQueryModel>(entity);

        return model;
    }
}
