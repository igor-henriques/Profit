namespace Profit.Domain.Interfaces.Services;

/// <summary>
/// Provides a mechanism for storing Commands into a storage queue.
/// </summary>
public interface IStorageQueueService
{
    /// <summary>
    /// Enqueues a Command into a storage queue.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="message"></param>
    /// <returns></returns>
    Task EnqueueAsync<T>(T message) where T : class;

    /// <summary>
    /// Enqueues a batch of Commands into a storage queue.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="messages"></param>
    /// <returns></returns>
    Task EnqueueAsync<T>(IEnumerable<T> messages) where T : class;
}