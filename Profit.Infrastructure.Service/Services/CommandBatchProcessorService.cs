namespace Profit.Infrastructure.Service.Services;

/// <summary>
/// Provides a mechanism for batching commands.
/// Once the batch reachs a predefined size, it will be processed.
/// When processed, this batch is sent to a storage queue for observability.
/// </summary>
/// <typeparam name="T">A Command type</typeparam>
public sealed class CommandBatchProcessorService<T> : ICommandBatchProcessorService<T>
{
    private readonly IStorageQueueService _queueService;
    private readonly ILogger<CommandBatchProcessorService<T>> _logger;
    private readonly ConcurrentBag<T> _bag;

    public CommandBatchProcessorService(
        IStorageQueueService queueService,
        ILogger<CommandBatchProcessorService<T>> logger)
    {
        _bag = new ConcurrentBag<T>();
        _queueService = queueService;
        _logger = logger;
    }

    public void Enqueue(T command)
    {
        _bag.Add(command);
        _logger.LogInformation("Command {command} was enqueued", command);
    }

    public int GetBatchSize() => _bag.Count;

    public async ValueTask Process()
    {
        if (_bag.Count < 0)
        {
            _logger.LogInformation($"No commands to process");
            return;
        }

        await _queueService.EnqueueAsync(_bag);
    }

    public void ClearBatchProcessor()
    {
        _bag.Clear();
        _logger.LogInformation($"Batch was cleared");
    }
}
