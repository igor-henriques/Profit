namespace Profit.Infrastructure.Service.Services;

public sealed class StorageQueueService : IStorageQueueService
{
    private readonly QueueClient _queueClient;

    public StorageQueueService(IConfiguration configuration)
    {
        const string QUEUE_NAME = "profit-commands";
        var connectionString = configuration.GetConnectionString("AzureStorage");
        _queueClient = new QueueClient(connectionString, QUEUE_NAME);
    }

    public Task EnqueueAsync<T>(T message) where T : class
    {
        return Task.FromResult(_queueClient.SendMessageAsync(JsonConvert.SerializeObject(message)));
    }

    public Task EnqueueAsync<T>(IEnumerable<T> messages) where T : class
    {
        foreach (var item in messages)
        {
            EnqueueAsync(item);
        }

        return Task.CompletedTask;
    }
}