namespace Profit.Domain.Pipelines;

public sealed class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

    public LoggingBehavior(
        ILogger<LoggingBehavior<TRequest, TResponse>> logger)
    {
        _logger = logger;
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
            var log = new RequestCommandQueryLog()
            {
                RequestId = requestId,
                Timestamp = timestamp,
                ElapsedMilliseconds = stopwatch.ElapsedMilliseconds,
                Request = request,
                Message = message
            };

            _logger.Log(
                string.IsNullOrEmpty(log.Message) ? LogLevel.Information : LogLevel.Error,
                "{log}", log);
        }
    }
}
