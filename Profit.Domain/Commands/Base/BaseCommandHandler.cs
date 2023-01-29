namespace Profit.Domain.Commands.Base;

public abstract class BaseCommandHandler<T> where T : BaseCommand
{
    private readonly ICommandBatchProcessorService<T> _commandBatchProcessor;
    private readonly int _batchMaxSize;

    public BaseCommandHandler(
        ICommandBatchProcessorService<T> commandBatchProcessor,
        int batchMaxSize = 0)
    {
        _commandBatchProcessor = commandBatchProcessor;
        _batchMaxSize = batchMaxSize;
    }

    public void EnqueueCommandForStoraging(T command)
    {
        _commandBatchProcessor.Enqueue(command);
    }

    public async Task ProcessBatchAsync()
    {
        if (_commandBatchProcessor.GetBatchSize() > _batchMaxSize)
        {
            await _commandBatchProcessor.Process();
        }
    }
}
