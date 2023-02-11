namespace Profit.Domain.Models;

internal readonly record struct RequestCommandQueryLog<T>
{
    public Guid RequestId { get; init; }
    public DateTimeOffset Timestamp { get; init; }
    public long ElapsedMilliseconds { get; init; }
    public T Request { get; init; }
    public string Message { get; init; }
}