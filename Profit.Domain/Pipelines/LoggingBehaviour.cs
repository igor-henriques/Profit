namespace Profit.Domain.Pipelines;

public sealed class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IStorageQueueService _storageQueueService;
    private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

    public LoggingBehavior(
        ILogger<LoggingBehavior<TRequest, TResponse>> logger,
        IStorageQueueService storageQueueService)
    {
        _logger = logger;
        _storageQueueService = storageQueueService;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var requestId = Guid.NewGuid();
        var timestamp = DateTime.Now;
        var stopwatch = Stopwatch.StartNew();
        string message = null;

        try
        {
            var response = await next();
            return response;
        }
        catch (Exception ex)
        {
            message = ex.ToString();
            throw;
        }
        finally
        {
            var log = new RequestCommandQueryLog<TRequest>()
            {
                RequestId = requestId,
                Timestamp = timestamp,
                ElapsedMilliseconds = stopwatch.ElapsedMilliseconds,
                Request = request,
                Message = message
            };

            await _storageQueueService.EnqueueValueTypeAsync(log);

            _logger.Log(
                string.IsNullOrEmpty(log.Message) ? LogLevel.Error : LogLevel.Information,
                "{log}", log);
        }
    }
}
