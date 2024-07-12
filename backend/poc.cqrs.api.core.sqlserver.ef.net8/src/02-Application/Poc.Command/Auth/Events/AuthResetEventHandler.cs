using MediatR;
using Microsoft.Extensions.Configuration;
using poc.core.api.net8.Enumerado;
using poc.core.api.net8.Helper;
using poc.core.api.net8.Interface;
using Poc.Command.Auth.Mapper;
using Poc.Contract.Command.Auth.Interfaces;
using Poc.Contract.Command.Notification.Request;
using Poc.Domain.Entities.User.Events.Auth;

namespace Poc.Command.Auth.Events;

public class AuthResetEventHandler : INotificationHandler<AuthResetEvent>
{
    private readonly IAuthResetCommandStore _repo;
    private readonly IMediator _mediator;
    private readonly IConfiguration _configuration;
    private readonly IAuthService _authService;

    public AuthResetEventHandler(IAuthResetCommandStore repo,
                                 IMediator mediator,
                                 IConfiguration configuration,
                                 IAuthService authService)
    {
        _repo = repo;
        _mediator = mediator;
        _configuration = configuration;
        _authService = authService;
    }

    public async Task Handle(AuthResetEvent authevent, CancellationToken cancellationToken)
    {
        var token = _authService.GenerateJwtToken(authevent.Id.ToString(), authevent.Email);
        var mapperMongoDb = AuthResetModelMapper.MapEvetToCache(authevent, token);
        await _repo.Create(mapperMongoDb);

        if (authevent.Notification == ENotificationType.Email)
            await EmailCommand(authevent, token);

        if (authevent.Notification == ENotificationType.SMS)
            await SMSCommand(authevent, token);

        if (authevent.Notification == ENotificationType.WhatsApp)
            await WhatsAppCommand(authevent, token);
    }

    #region Email, WhatsApp e SMS
    private async Task WhatsAppCommand(AuthResetEvent authevent, string token)
    {
        await _mediator.Send(new CreateNotificationWhatsAppCommand()
        {
            From = _configuration.GetValue<string>(AuthConsts.NEWPASSWORD_FROM),
            NotificationType = ENotificationType.WhatsApp,
            Body = Email(authevent, token),
            To = authevent.Phone // Phone
        });
    }

    private async Task SMSCommand(AuthResetEvent authevent, string token)
    {
        await _mediator.Send(new CreateNotificationSMSCommand()
        {
            From = _configuration.GetValue<string>(AuthConsts.NEWPASSWORD_PHONE),
            NotificationType = ENotificationType.SMS,
            Body = Email(authevent, token),
            To = authevent.Phone // Phone
        });
    }

    private async Task EmailCommand(AuthResetEvent authevent, string token)
    {
        await _mediator.Send(new CreateNotificationSendGridEmailCommand()
        {
            From = _configuration.GetValue<string>(AuthConsts.NEWPASSWORD_PHONE),
            NotificationType = ENotificationType.Email,
            Name = authevent.FirstName,
            Subject = EmailHelper.GeneratePasswordResetSubject(),
            HtmlContent = Email(authevent, token),
            To = authevent.Email
        });
    }

    private string Email(AuthResetEvent entity, string token)
    {
        var passwordResetInfo = new PasswordResetInfo
        {
            UserName = entity.FirstName,
            ResetLink = $"{_configuration.GetValue<string>(AuthConsts.NEWPASSWORD)}{token}",
            ExpiryTime = TimeSpan.FromHours(2)
        };
        return EmailHelper.GeneratePasswordResetMessage(passwordResetInfo); ;
    }
    #endregion
}
