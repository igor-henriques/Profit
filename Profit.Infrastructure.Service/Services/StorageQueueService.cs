namespace Profit.Infrastructure.Service.Services;

public sealed class StorageQueueService : IStorageQueueService
{
    private readonly QueueClient _queueClient;

    public StorageQueueService(IConfiguration configuration)
    {
        var queueName = configuration.GetSection("CommandBatchStoraging:StorageQueueName").Value;
        var connectionString = configuration.GetConnectionString("AzureStorage");
        _queueClient = new QueueClient(connectionString, queueName);
    }

    public Task EnqueueAsync<T>(T message) where T : class
    {
        return Task.FromResult(_queueClient.SendMessageAsync(JsonConvert.SerializeObject(message)));
    }

    public Task EnqueueValueTypeAsync<T>(T message) where T : struct
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