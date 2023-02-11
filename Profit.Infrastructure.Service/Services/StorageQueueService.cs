﻿namespace Profit.Infrastructure.Service.Services;

public sealed class StorageQueueService : IStorageQueueService
{
    private readonly QueueClient _queueClient;

    public StorageQueueService(IConfiguration configuration)
    {
        var queueName = configuration.GetSection("CommandBatchStoraging:StorageQueueName").Value;
        var connectionString = configuration.GetConnectionString("AzureStorage");
        _queueClient = new QueueClient(connectionString, queueName);
    }

    public Task EnqueueAsync<T>(T message, CancellationToken cancellationToken) where T : class
    {
        return Task.FromResult(_queueClient.SendMessageAsync(JsonConvert.SerializeObject(message), cancellationToken));
    }

    public Task EnqueueValueTypeAsync<T>(T message, CancellationToken cancellationToken) where T : struct
    {
        return Task.FromResult(_queueClient.SendMessageAsync(JsonConvert.SerializeObject(message), cancellationToken));
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