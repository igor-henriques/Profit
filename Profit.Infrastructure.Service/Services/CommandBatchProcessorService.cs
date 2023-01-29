namespace Profit.Infrastructure.Service.Services;

public sealed class CommandBatchProcessorService<T> : ICommandBatchProcessorService<T>
    where T : BaseCommand
{
    private readonly IStorageQueueService _queueService;
    private readonly ConcurrentBag<T> _bag;

    public CommandBatchProcessorService(IStorageQueueService queueService)
    {
        _bag = new ConcurrentBag<T>();
        _queueService = queueService;
    }

    public void Enqueue(T command) => _bag.Add(command);

    public int GetBatchSize() => _bag.Count;

    public async Task Process() => await _queueService.EnqueueAsync(_bag);

    public void ClearBatchProcessor() => _bag.Clear();
}
