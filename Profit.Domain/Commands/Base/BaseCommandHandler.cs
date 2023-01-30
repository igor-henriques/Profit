namespace Profit.Domain.Commands.Base;

/// <summary>
/// Provides a base class for command handlers.
/// With <see cref="ICommandBatchProcessorService<T>"/>,
/// All CommandHandlers can enqueue its commands for observability
/// </summary>
/// <typeparam name="T">A Command type</typeparam>
public abstract class BaseCommandHandler<T> where T : BaseCommand
{
    private readonly ICommandBatchProcessorService<T> _commandBatchProcessor;
    private readonly int _batchMaxSize;

    public BaseCommandHandler(
        ICommandBatchProcessorService<T> commandBatchProcessor,
        IConfiguration configuration)
    {
        if (!int.TryParse(configuration.GetSection("CommandBatchStoraging:BatchSize").Value, out _batchMaxSize))
            throw new ArgumentException("Invalid configuration for BatchSize");

        _commandBatchProcessor = commandBatchProcessor;
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
