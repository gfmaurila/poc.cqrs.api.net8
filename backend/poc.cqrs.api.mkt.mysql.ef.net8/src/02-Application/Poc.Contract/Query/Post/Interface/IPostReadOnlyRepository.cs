using Poc.Contract.Query.Post.QueriesModel;

namespace Poc.Contract.Query.Post.Interface;

public interface IPostReadOnlyRepository
{
    Task<PostQueryModel> GetByTitle(string title);
    Task<List<PostQueryModel>> Get();
    Task<PostQueryModel> Get(Guid id);
}
