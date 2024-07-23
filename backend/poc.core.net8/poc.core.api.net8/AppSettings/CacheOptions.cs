using System.Diagnostics.CodeAnalysis;

namespace poc.core.api.net8.AppSettings;

[ExcludeFromCodeCoverage]
public class CacheOptions
{
    public const string ConfigSectionPath = nameof(CacheOptions);
    public int AbsoluteExpirationInHours { get; set; }
    public int SlidingExpirationInSeconds { get; set; }
    public int DbIndex { get; set; }
}