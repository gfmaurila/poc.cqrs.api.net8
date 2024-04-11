using MediatR;
using Microsoft.Extensions.Logging;
using poc.core.api.net8.Interface;
using Poc.Contract.Query.MKT.Post.Interface;
using Poc.Contract.Query.MKT.Post.QueriesModel;
using Poc.Contract.Query.MKT.Post.Request;
using Poc.Domain.Entities.MKT.Post.Events;

namespace Poc.Command.MKT.Post.Events;

public class PostDeleteEventHandler : INotificationHandler<PostDeleteEvent>
{
    private readonly ILogger<PostDeleteEventHandler> _logger;
    private readonly IPostReadOnlyRepository _repo;
    private readonly IRedisCacheService<List<PostQueryModel>> _cacheService;
    public PostDeleteEventHandler(ILogger<PostDeleteEventHandler> logger,
                                   IPostReadOnlyRepository repo,
                                   IRedisCacheService<List<PostQueryModel>> cacheService)
    {
        _logger = logger;
        _repo = repo;
        _cacheService = cacheService;
    }

    public async Task Handle(PostDeleteEvent notification, CancellationToken cancellationToken)
    {
        const string cacheKey = nameof(GetPostQuery);
        await _cacheService.DeleteAsync(cacheKey);
        await _cacheService.GetOrCreateAsync(cacheKey, _repo.Get, TimeSpan.FromHours(2));
    }
}
