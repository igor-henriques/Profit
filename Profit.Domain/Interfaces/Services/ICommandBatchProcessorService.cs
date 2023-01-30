namespace Profit.Domain.Interfaces.Services;

/// <summary>
/// Provides a mechanism for batching commands.
/// Once the batch reachs a predefined size, it will be processed.
/// When processed, this batch is sent to a storage queue for observability.
/// </summary>
/// <typeparam name="T">A Command type</typeparam>
public interface ICommandBatchProcessorService<T> where T : BaseCommand
{
    /// <summary>
    /// Enqueues a command to the batch
    /// </summary>
    /// <param name="command"></param>
    void Enqueue(T command);

    /// <summary>
    /// Returns the current batch size
    /// </summary>
    /// <returns></returns>
    int GetBatchSize();

    /// <summary>
    /// Process the batch
    /// </summary>
    /// <returns></returns>
    ValueTask Process();

    /// <summary>
    /// Clears the batch
    /// </summary>
    void ClearBatchProcessor();
}