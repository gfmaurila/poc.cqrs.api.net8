using Ardalis.Result;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using poc.core.api.net8.Interface;
using Poc.Command.Core.Auth;
using Poc.Command.Core.Auth.Events;
using Poc.Command.Core.Auth.Service;
using Poc.Command.Core.User;
using Poc.Command.Core.User.Events;
using Poc.Command.HR.Region;
using Poc.Command.HR.Region.Events;
using Poc.Command.MKT.Post;
using Poc.Command.MKT.Post.Events;
using Poc.Command.Notification;
using Poc.Contract.Command.Core.Auth.Request;
using Poc.Contract.Command.Core.Auth.Response;
using Poc.Contract.Command.Core.Auth.Validators;
using Poc.Contract.Command.Core.User.Request;
using Poc.Contract.Command.Core.User.Response;
using Poc.Contract.Command.Core.User.Validators;
using Poc.Contract.Command.HR.Region.Request;
using Poc.Contract.Command.HR.Region.Response;
using Poc.Contract.Command.HR.Region.Validators;
using Poc.Contract.Command.MKT.Post.Request;
using Poc.Contract.Command.MKT.Post.Response;
using Poc.Contract.Command.MKT.Post.Validators;
using Poc.Contract.Command.Notification.Request;
using Poc.Domain.Entities.HR.Region.Events;
using Poc.Domain.Entities.MKT.Post.Events;
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

        #region Oracle
        services.AddTransient<IRequestHandler<CreateRegionCommand, Result<CreateRegionResponse>>, CreateRegionCommandHandler>();
        services.AddTransient<CreateRegionCommandValidator>();
        services.AddTransient<INotificationHandler<RegionCreatedEvent>, RegionCreatedEventHandler>();

        services.AddTransient<IRequestHandler<UpdateRegionCommand, Result>, UpdateRegionCommandHandler>();
        services.AddTransient<UpdateRegionCommandValidator>();
        services.AddTransient<INotificationHandler<RegionUpdateEvent>, RegionUpdateEventHandler>();

        services.AddTransient<IRequestHandler<DeleteRegionCommand, Result>, DeleteRegionCommandHandler>();
        services.AddTransient<INotificationHandler<RegionDeleteEvent>, RegionDeleteEventHandler>();
        services.AddTransient<DeleteRegionCommandValidator>();
        #endregion

        #region MySQL
        services.AddTransient<IRequestHandler<CreatePostCommand, Result<CreatePostResponse>>, CreatePostCommandHandler>();
        services.AddTransient<CreatePostCommandValidator>();
        services.AddTransient<INotificationHandler<PostCreateEvent>, PostCreateEventHandler>();

        services.AddTransient<IRequestHandler<UpdatePostCommand, Result>, UpdatePostCommandHandler>();
        services.AddTransient<UpdatePostCommandValidator>();
        services.AddTransient<INotificationHandler<PostUpdateEvent>, PostUpdateEventHandler>();

        services.AddTransient<IRequestHandler<DeletePostCommand, Result>, DeletePostCommandHandler>();
        services.AddTransient<INotificationHandler<PostDeleteEvent>, PostDeleteEventHandler>();
        services.AddTransient<DeletePostCommandValidator>();
        #endregion
    }
}
