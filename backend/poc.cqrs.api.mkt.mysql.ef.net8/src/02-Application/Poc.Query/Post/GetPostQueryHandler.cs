using Ardalis.Result;
using MediatR;
using poc.core.api.net8.Interface;
using Poc.Contract.Query.Post.Interface;
using Poc.Contract.Query.Post.QueriesModel;
using Poc.Contract.Query.Post.Request;

namespace Poc.Query.Post;

public class GetPostQueryHandler : IRequestHandler<GetPostQuery, Result<List<PostQueryModel>>>
{
    private readonly IPostReadOnlyRepository _repo;
    private readonly IRedisCacheService<List<PostQueryModel>> _cacheService;
    public GetPostQueryHandler(IPostReadOnlyRepository repo, IRedisCacheService<List<PostQueryModel>> cacheService)
    {
        _repo = repo;
        _cacheService = cacheService;
    }

    public async Task<Result<List<PostQueryModel>>> Handle(GetPostQuery request, CancellationToken cancellationToken)
    {
        const string cacheKey = nameof(GetPostQuery);
        return Result.Success(await _cacheService.GetOrCreateAsync(cacheKey, _repo.Get, TimeSpan.FromHours(2)));
    }
}
