using poc.core.api.net8.Abstractions;
using Poc.Domain.Entities.Post;

namespace Poc.Contract.Command.Post.Interfaces;

public interface IPostWriteOnlyRepository : IMySQLBaseRepository<PostEntity>
{
    Task<bool> ExistsByTitleAsync(string title);
}
