using MediatR;
using Microsoft.Extensions.Logging;
using Poc.Contract.Command.Core.Auth.Interfaces;
using Poc.Contract.Command.Core.Auth.ViewModels;
using Poc.Domain.Entities.User.Events.Auth;

namespace Poc.Command.Core.Auth.Events;

public class AuthEventHandler : INotificationHandler<AuthEvent>
{
    private readonly IAuthTokenCommandStore _repo;
    private readonly ILogger<AuthEventHandler> _logger;

    public AuthEventHandler(IAuthTokenCommandStore repo, ILogger<AuthEventHandler> logger)
    {
        _repo = repo;
        _logger = logger;
    }

    public async Task Handle(AuthEvent authevent, CancellationToken cancellationToken)
    {
        await _repo.Create(new AuthTokenModel()
        {
            Id = authevent.Id,
            Nome = authevent.Nome,
            Email = authevent.Email,
            Token = authevent.Token,
            CreatedAt = authevent.CreatedAt
        });
    }
}
