using System.Diagnostics.CodeAnalysis;

namespace poc.core.api.net8.AppSettings;

[ExcludeFromCodeCoverage]
public sealed class CacheOptions : BaseOptions
{
    public const string ConfigSectionPath = nameof(CacheOptions);

    public int AbsoluteExpirationInHours { get; private init; }
    public int SlidingExpirationInSeconds { get; private init; }
    public int DbIndex { get; private init; }

}