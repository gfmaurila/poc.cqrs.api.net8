using Poc.Contract.Query.MKT.Post.QueriesModel;

namespace Poc.Contract.Query.MKT.Post.Interface;

public interface IPostReadOnlyRepository
{
    Task<PostQueryModel> GetByTitle(string title);
    Task<List<PostQueryModel>> Get();
    Task<PostQueryModel> Get(Guid id);
}
