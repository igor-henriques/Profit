namespace Profit.Domain.Commands.Base;

/// <summary>
/// Provides a basic structure for commands.
/// These informations are usefull for observability and logging purposes.
/// With JsonIgnoreAttribute, these informations are ignored on request structure.
/// </summary>
public abstract record BaseCommand
{
    [JsonIgnore]
    public Guid CommandId { get; init; }

    [JsonIgnore]
    public DateTimeOffset Timestamp { get; init; }

    public BaseCommand()
    {
        CommandId = Guid.NewGuid();
        Timestamp = DateTimeOffset.UtcNow;
    }
}