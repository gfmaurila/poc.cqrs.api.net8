using poc.core.api.net8.Abstractions;
using Poc.Domain.Entities.MKT.Post;

namespace Poc.Contract.Command.MKT.Post.Interfaces;

public interface IPostWriteOnlyRepository : IMySQLBaseRepository<PostEntity>
{
    Task<bool> ExistsByTitleAsync(string title);
}
