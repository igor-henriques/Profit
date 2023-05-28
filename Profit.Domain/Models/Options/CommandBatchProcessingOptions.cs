namespace Profit.Domain.Models.Options;

public sealed record CommandBatchProcessingOptions
{
    public string StorageQueueName { get; init; }
    public int BatchSize { get; init; }
}
