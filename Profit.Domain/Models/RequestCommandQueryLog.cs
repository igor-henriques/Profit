namespace Profit.Domain.Models;

public readonly record struct RequestCommandQueryLog
{
    public Guid RequestId { get; init; }
    public DateTimeOffset Timestamp { get; init; }
    public long ElapsedMilliseconds { get; init; }

    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public object Request { get; init; }

    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public string Message { get; init; }
}