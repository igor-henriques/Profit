namespace Profit.Domain.Interfaces.Services;

public interface ICommandBatchProcessorService<T> where T : BaseCommand;
{
    void Enqueue(T command);
    int GetBatchSize();
    Task Process();
}
