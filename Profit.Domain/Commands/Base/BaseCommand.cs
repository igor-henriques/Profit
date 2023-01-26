namespace Profit.Domain.Commands.Base;

public abstract record BaseCommand
{
    public Guid CommandId { get; init; }
    public DateTimeOffset Timestamp { get; init; }
}