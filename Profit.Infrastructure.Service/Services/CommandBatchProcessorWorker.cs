namespace Profit.Infrastructure.Service.Services;

public sealed class CommandBatchProcessorWorker<T> : BackgroundService
{
    private readonly ICommandBatchProcessorService<T> _commandBatchProcessorService;
    private readonly ILogger<CommandBatchProcessorWorker<T>> _logger;
    private readonly PeriodicTimer _timer;
    private readonly int _batchMaxSize;

    public CommandBatchProcessorWorker(
        ICommandBatchProcessorService<T> commandBatchProcessorService,
        IConfiguration configuration,
        ILogger<CommandBatchProcessorWorker<T>> logger)
    {

        _batchMaxSize = configuration.GetValue<int>("CommandBatchStoraging:BatchSize");
        _commandBatchProcessorService = commandBatchProcessorService;
        _logger = logger;
        _timer = new PeriodicTimer(TimeSpan.FromSeconds(10));
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Initializing {CommandBatchProcessorWorker}", nameof(CommandBatchProcessorWorker<T>));

        while (!stoppingToken.IsCancellationRequested && await _timer.WaitForNextTickAsync(stoppingToken))
        {
            if (_commandBatchProcessorService.GetBatchSize() >= _batchMaxSize)
            {
                await _commandBatchProcessorService.Process(stoppingToken);
                _logger.LogInformation("{batchSize} commands processed", _commandBatchProcessorService.GetBatchSize());
            }
        }
    }
}
