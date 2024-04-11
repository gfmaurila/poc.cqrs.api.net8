using Microsoft.Extensions.DependencyInjection;
using Poc.Core.Handle;
using Poc.Core.Interface;

namespace Poc.Core;

public class CoreInitializer
{
    public static void Initialize(IServiceCollection services)
    {
        services.AddTransient<INotificationHandle, NotificationHandle>();
    }
}
