using MongoDB.Driver;
using poc.core.api.net8.Abstractions;
using System.Linq.Expressions;

namespace poc.core.api.net8.Interface;

public interface IReadDbContext : IDisposable
{
    string ConnectionString { get; }
    IMongoCollection<TQueryModel> GetCollection<TQueryModel>() where TQueryModel : IQueryModel;
    Task UpsertAsync<TQueryModel>(TQueryModel queryModel, Expression<Func<TQueryModel, bool>> upsertFilter) where TQueryModel : IQueryModel;
    Task DeleteAsync<TQueryModel>(Expression<Func<TQueryModel, bool>> deleteFilter) where TQueryModel : IQueryModel;
    Task CreateCollectionsAsync();
}
