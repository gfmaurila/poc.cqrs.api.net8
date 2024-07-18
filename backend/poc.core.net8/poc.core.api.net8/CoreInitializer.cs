using Microsoft.Extensions.DependencyInjection;
using poc.core.api.net8.Handle;
using poc.core.api.net8.Interface;
using System.Diagnostics.CodeAnalysis;

namespace poc.core.api.net8;

[ExcludeFromCodeCoverage]
public class CoreInitializer
{
    public static void Initialize(IServiceCollection services)
    {
        services.AddTransient<INotificationHandle, NotificationHandle>();
    }
}
