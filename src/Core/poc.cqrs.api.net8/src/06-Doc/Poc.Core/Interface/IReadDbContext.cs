using MongoDB.Driver;
using Poc.Core.Abstractions;
using System.Linq.Expressions;

namespace Poc.Core.Interface;

public interface IReadDbContext : IDisposable
{
    string ConnectionString { get; }
    IMongoCollection<TQueryModel> GetCollection<TQueryModel>() where TQueryModel : IQueryModel;
    Task UpsertAsync<TQueryModel>(TQueryModel queryModel, Expression<Func<TQueryModel, bool>> upsertFilter) where TQueryModel : IQueryModel;
    Task DeleteAsync<TQueryModel>(Expression<Func<TQueryModel, bool>> deleteFilter) where TQueryModel : IQueryModel;
    Task CreateCollectionsAsync();
}
