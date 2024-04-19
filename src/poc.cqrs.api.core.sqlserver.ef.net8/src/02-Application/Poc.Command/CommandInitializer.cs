using Ardalis.Result;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using poc.core.api.net8.Interface;
using Poc.Command.Auth;
using Poc.Command.Auth.Events;
using Poc.Command.Auth.Service;
using Poc.Command.Notification;
using Poc.Command.User;
using Poc.Command.User.Events;
using Poc.Contract.Command.Auth.Request;
using Poc.Contract.Command.Auth.Response;
using Poc.Contract.Command.Auth.Validators;
using Poc.Contract.Command.Notification.Request;
using Poc.Contract.Command.User.Request;
using Poc.Contract.Command.User.Response;
using Poc.Contract.Command.User.Validators;
using Poc.Domain.Entities.User.Events.Auth;
using Poc.Domain.Entities.User.Events.Crud;

namespace Poc.Command;

public class CommandInitializer
{
    public static void Initialize(IServiceCollection services)
    {
        services.AddMediatR(typeof(AuthCommandHandler).Assembly);
        services.AddMediatR(typeof(AuthCommand));

        #region SQLServer
        // Usuario
        services.AddTransient<IRequestHandler<CreateUserCommand, Result<CreateUserResponse>>, CreateUserCommandHandler>();
        services.AddTransient<CreateUserCommandValidator>();
        services.AddTransient<INotificationHandler<UserCreatedEvent>, UserCreatedEventHandler>();

        services.AddTransient<IRequestHandler<DeleteUserCommand, Result>, DeleteUserCommandHandler>();
        services.AddTransient<INotificationHandler<UserDeletedEvent>, UserDeletedEventHandler>();
        services.AddTransient<DeleteUserCommandValidator>();

        services.AddTransient<IRequestHandler<UpdateUserCommand, Result>, UpdateUserCommandHandler>();
        services.AddTransient<INotificationHandler<UserUpdatedEvent>, UserUpdatedEventHandler>();
        services.AddTransient<UpdateUserCommandValidator>();

        services.AddTransient<IRequestHandler<UpdatePasswordUserCommand, Result>, UpdatePasswordUserCommandHandler>();
        services.AddTransient<UpdatePasswordUserCommandValidator>();

        services.AddTransient<IRequestHandler<UpdateEmailUserCommand, Result>, UpdateEmailUserCommandHandler>();
        services.AddTransient<UpdateEmailUserCommandValidator>();

        services.AddTransient<IRequestHandler<UpdateRoleUserCommand, Result>, UpdateRoleUserCommandHandler>();
        services.AddTransient<UpdateRoleUserCommandValidator>();

        // Auth
        services.AddTransient<IRequestHandler<AuthCommand, Result<AuthTokenResponse>>, AuthCommandHandler>();
        services.AddTransient<AuthCommandValidator>();
        services.AddTransient<INotificationHandler<AuthEvent>, AuthEventHandler>();
        services.AddTransient<IAuthService, AuthService>();

        services.AddTransient<IRequestHandler<AuthResetPasswordCommand, Result>, AuthResetPasswordCommandHandler>();
        services.AddTransient<INotificationHandler<AuthResetEvent>, AuthResetEventHandler>();
        services.AddTransient<AuthResetPasswordCommandValidator>();

        services.AddTransient<IRequestHandler<AuthNewPasswordCommand, Result>, AuthNewPasswordCommandHandler>();
        services.AddTransient<AuthNewPasswordCommandValidator>();
        #endregion

        #region Notificações
        services.AddTransient<IRequestHandler<CreateNotificationSMSCommand, Result>, CreateNotificationSMSCommandHandler>();
        services.AddTransient<IRequestHandler<CreateNotificationWhatsAppCommand, Result>, CreateNotificationWhatsAppCommandHandler>();
        services.AddTransient<IRequestHandler<CreateNotificationSendGridEmailCommand, Result>, CreateNotificationSendGridEmailCommandHandler>();
        #endregion
    }
}
