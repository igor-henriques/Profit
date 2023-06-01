namespace Profit.Infrastructure.Service.Workers;

public sealed class CommandBatchProcessorWorker<T> : BackgroundService
{
    private readonly ICommandBatchProcessorService<T> _commandBatchProcessorService;
    private readonly IOptions<CommandBatchProcessingOptions> _options;
    private readonly ILogger<CommandBatchProcessorWorker<T>> _logger;
    private readonly PeriodicTimer _timer;

    public CommandBatchProcessorWorker(
        ICommandBatchProcessorService<T> commandBatchProcessorService,
        IOptions<CommandBatchProcessingOptions> options,
        ILogger<CommandBatchProcessorWorker<T>> logger)
    {

        _commandBatchProcessorService = commandBatchProcessorService;
        _options = options;
        _logger = logger;
        _timer = new PeriodicTimer(TimeSpan.FromSeconds(10));
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Initializing {CommandBatchProcessorWorker}", nameof(CommandBatchProcessorWorker<T>));

        while (!stoppingToken.IsCancellationRequested && await _timer.WaitForNextTickAsync(stoppingToken))
        {
            if (_commandBatchProcessorService.GetBatchSize() >= _options.Value.BatchSize)
            {
                try
                {
                    await _commandBatchProcessorService.Process(stoppingToken);
                    _logger.LogInformation("{batchSize} commands processed", _commandBatchProcessorService.GetBatchSize());
                }
                catch (Exception e)
                {
                    _logger.LogError("Error while processing {commandBatchProcessorService}: {exception}",
                        nameof(CommandBatchProcessorService<T>),
                        e.ToString());
                }
            }
        }
    }
}
