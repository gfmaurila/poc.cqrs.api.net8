using Microsoft.Extensions.DependencyInjection;
using poc.core.api.net8.AppSettings;

namespace poc.core.api.net8.Extensions;

public static class ServicesCollectionExtensions
{
    public static void ConfigureAppSettings(this IServiceCollection services)
    {
        services.AddOptionsWithValidation<ConnectionOptions>(ConnectionOptions.ConfigSectionPath);
        services.AddOptionsWithValidation<CacheOptions>(CacheOptions.ConfigSectionPath);
    }

    public static IServiceCollection AddOptionsWithValidation<TOptions>(this IServiceCollection services, string configSectionPath)
        where TOptions : BaseOptions
    {
        return services
            .AddOptions<TOptions>()
            .BindConfiguration(configSectionPath, options => options.BindNonPublicProperties = true)
            .ValidateDataAnnotations()
            .ValidateOnStart()
            .Services;
    }


}