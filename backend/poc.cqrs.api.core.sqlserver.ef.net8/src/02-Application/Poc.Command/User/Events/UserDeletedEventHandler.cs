using MediatR;
using Microsoft.Extensions.Logging;
using poc.core.api.net8.Interface;
using Poc.Contract.Query.User.EF.Interface;
using Poc.Contract.Query.User.EF.QueriesModel;
using Poc.Contract.Query.User.Request;
using Poc.Domain.Entities.User.Events.Crud;

namespace Poc.Command.User.Events;

public class UserDeletedEventHandler : INotificationHandler<UserDeletedEvent>
{
    private readonly ILogger<UserDeletedEventHandler> _logger;
    private readonly IUserReadOnlyRepository _repo;
    private readonly IRedisCacheService<List<UserQueryModel>> _cacheService;
    public UserDeletedEventHandler(ILogger<UserDeletedEventHandler> logger,
                                   IUserReadOnlyRepository repo,
                                   IRedisCacheService<List<UserQueryModel>> cacheService)
    {
        _logger = logger;
        _repo = repo;
        _cacheService = cacheService;
    }

    public async Task Handle(UserDeletedEvent notification, CancellationToken cancellationToken)
    {
        const string cacheKey = nameof(GetUserQuery);
        await _cacheService.DeleteAsync(cacheKey);
        await _cacheService.GetOrCreateAsync(cacheKey, _repo.GetAllAsync, TimeSpan.FromHours(2));
    }
}
