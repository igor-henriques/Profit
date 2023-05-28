namespace Profit.Domain.Models.Options;

public sealed record CacheOptions
{
    public int SecondsDuration { get; init; }
}
