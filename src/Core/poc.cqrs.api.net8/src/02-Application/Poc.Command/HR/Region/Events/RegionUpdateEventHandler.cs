using MediatR;
using Microsoft.Extensions.Logging;
using poc.core.api.net8.Interface;
using Poc.Contract.Query.HR.Region.Interfaces;
using Poc.Contract.Query.HR.Region.Request;
using Poc.Contract.Query.HR.Region.ViewModels;
using Poc.Domain.Entities.HR.Region.Events;

namespace Poc.Command.HR.Region.Events;

public class RegionUpdateEventHandler : INotificationHandler<RegionUpdateEvent>
{
    private readonly ILogger<RegionUpdateEventHandler> _logger;
    private readonly IRegionsReadOnlyRepository _repo;
    private readonly IRedisCacheService<List<RegionQueryModel>> _cacheService;
    public RegionUpdateEventHandler(ILogger<RegionUpdateEventHandler> logger,
                                   IRegionsReadOnlyRepository repo,
                                   IRedisCacheService<List<RegionQueryModel>> cacheService)
    {
        _logger = logger;
        _repo = repo;
        _cacheService = cacheService;
    }

    public async Task Handle(RegionUpdateEvent notification, CancellationToken cancellationToken)
    {
        const string cacheKey = nameof(GetRegionQuery);
        await _cacheService.DeleteAsync(cacheKey);
        await _cacheService.GetOrCreateAsync(cacheKey, _repo.Get, TimeSpan.FromHours(2));
    }
}
