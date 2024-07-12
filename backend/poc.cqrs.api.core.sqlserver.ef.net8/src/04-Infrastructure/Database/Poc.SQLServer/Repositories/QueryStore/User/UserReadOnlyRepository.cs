using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Poc.Contract.Query.User.EF.Interface;
using Poc.Contract.Query.User.EF.QueriesModel;
using Poc.SQLServer.Context;

namespace Poc.SQLServer.Repositories.QueryStore.User;

public class UserReadOnlyRepository : IUserReadOnlyRepository
{
    private readonly EFSqlServerContext _db;
    private readonly IMapper _mapper;
    public UserReadOnlyRepository(EFSqlServerContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<List<UserQueryModel>> GetAllAsync()
        => _mapper.Map<List<UserQueryModel>>(await _db.User.AsNoTracking().ToListAsync());

    public async Task<UserQueryModel> GetAuthByEmailPassword(string email, string passwordHash)
    {
        var entity = await _db.User.AsNoTracking()
                                   .Where(u => u.Email.Address == email &&
                                               u.Password == passwordHash)
                                   .FirstOrDefaultAsync();

        var model = _mapper.Map<UserQueryModel>(entity);

        return model;
    }

    public async Task<UserQueryModel> GetByEmailAsync(string email)
    {
        var entity = await _db.User.AsNoTracking()
                                   .Where(u => u.Email.Address == email)
                                   .FirstOrDefaultAsync();

        var model = _mapper.Map<UserQueryModel>(entity);

        return model;
    }

    public async Task<UserQueryModel> GetByIdAsync(Guid id)
    {
        var entity = await _db.User.AsNoTracking()
                                   .Where(u => u.Id == id)
                                   .FirstOrDefaultAsync();

        var model = _mapper.Map<UserQueryModel>(entity);

        return model;
    }

}
