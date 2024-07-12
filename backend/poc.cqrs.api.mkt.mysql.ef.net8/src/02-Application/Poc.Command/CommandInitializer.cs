using Ardalis.Result;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Poc.Command.Notification;
using Poc.Command.Post;
using Poc.Command.Post.Events;
using Poc.Contract.Command.Notification.Request;
using Poc.Contract.Command.Post.Request;
using Poc.Contract.Command.Post.Response;
using Poc.Contract.Command.Post.Validators;
using Poc.Domain.Entities.Post.Events;

namespace Poc.Command;

public class CommandInitializer
{
    public static void Initialize(IServiceCollection services)
    {
        #region Notificações
        services.AddTransient<IRequestHandler<CreateNotificationSMSCommand, Result>, CreateNotificationSMSCommandHandler>();
        services.AddTransient<IRequestHandler<CreateNotificationWhatsAppCommand, Result>, CreateNotificationWhatsAppCommandHandler>();
        services.AddTransient<IRequestHandler<CreateNotificationSendGridEmailCommand, Result>, CreateNotificationSendGridEmailCommandHandler>();
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
