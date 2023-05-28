namespace Profit.Infrastructure.Service.Services;

public sealed class StorageQueueService : IStorageQueueService
{
    private readonly QueueClient _queueClient;

    public StorageQueueService(
        IOptions<CommandBatchProcessingOptions> commandBatchOptions,
        IOptions<ConnectionStringsOptions> connectionStringsOptions)
    {
        ArgumentValidator.ThrowIfNullOrEmpty(connectionStringsOptions?.Value?.AzureStorage, nameof(connectionStringsOptions));
        ArgumentValidator.ThrowIfNullOrEmpty(commandBatchOptions.Value.StorageQueueName, nameof(commandBatchOptions));

        _queueClient = new QueueClient(connectionStringsOptions.Value.AzureStorage, commandBatchOptions.Value.StorageQueueName);
    }

    public Task EnqueueAsync<T>(T message, CancellationToken cancellationToken) where T : class
    {
        return _queueClient.SendMessageAsync(JsonConvert.SerializeObject(message), cancellationToken);
    }

    public Task EnqueueValueTypeAsync<T>(T message, CancellationToken cancellationToken) where T : struct
    {
        return _queueClient.SendMessageAsync(JsonConvert.SerializeObject(message), cancellationToken);
    }

    public Task EnqueueAsync<T>(IEnumerable<T> messages, CancellationToken cancellationToken) where T : class
    {
        foreach (var item in messages)
        {
            EnqueueAsync(item, cancellationToken);
        }

        return Task.CompletedTask;
    }
}