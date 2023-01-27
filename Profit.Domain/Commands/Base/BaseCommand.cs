namespace Profit.Domain.Commands.Base;

public abstract record BaseCommand
{
    [JsonIgnore()]
    public Guid CommandId { get; init; }

    [JsonIgnore]
    public DateTimeOffset Timestamp { get; init; }

    public BaseCommand()
    {
        CommandId = Guid.NewGuid();
        Timestamp = DateTimeOffset.UtcNow;
    }
}