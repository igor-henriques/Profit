namespace Profit.Infrastructure.Service.Services;

public sealed class CommandBatchProcessorService<T> : ICommandBatchProcessorService<T> where T : BaseCommand
{
    private readonly ConcurrentBag<T> _bag;

    public CommandBatchProcessorService()
    {
        _bag = new ConcurrentBag<T>();
    }

    public void Enqueue(T command)
    {        
        _bag.Add(command);        
    }

    public int GetBatchSize()
    {
        return _bag.Count;
    }

    public async Task Process()
    {
        //Process implementation
    }
}
