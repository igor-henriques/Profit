namespace Profit.Domain.Interfaces.Services;

public interface IStorageQueueService
{
    Task EnqueueAsync<T>(T message) where T : class;
    Task EnqueueAsync<T>(IEnumerable<T> messages) where T : class;
}