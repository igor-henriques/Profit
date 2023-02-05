namespace Profit.Infrastructure.Repository.Repositories.Base;
                
internal abstract class BaseRepository<T> : IBaseRepository<T> where T : Entity
{
    private readonly ProfitDbContext _context;
    private readonly ILogger<UnitOfWork> _logger;

    public BaseRepository(ProfitDbContext context, ILogger<UnitOfWork> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async ValueTask Add(T entity, CancellationToken cancellationToken = default)
    {
        var entityExists = await Exists(entity, cancellationToken);

        if (entityExists)
        {
            throw new InvalidOperationException("Entity already exists");
        }

        _context.Set<T>().Add(entity);
        _logger.LogInformation("{entity} was added", entity);
    }

    public Task BulkAdd(IEnumerable<T> entities)
    {
        _context.Set<T>().AddRange(entities);
        _logger.LogInformation("{entities} records were added", entities.Count());
        return Task.CompletedTask;
    }

    public async ValueTask<int> CountAsync(CancellationToken cancellationToken = default)
    {
        var response = await _context.Set<T>().CountAsync(cancellationToken);
        _logger.LogInformation("{response} records were counted", response);
        return response;
    }

    public void Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
        _logger.LogInformation("{entity} removed from database", entity);
    }

    public async ValueTask<bool> Exists(T entity, CancellationToken cancellationToken = default)
    {
        return await _context.Set<T>().AnyAsync(x => x.Id == entity.Id, cancellationToken);
    }

    public async ValueTask<IEnumerable<T>> GetManyAsync(CancellationToken cancellationToken = default)
    {
        var response = await _context.Set<T>().ToListAsync(cancellationToken);
        _logger.LogInformation("{response} records were retrieved", response.Count);
        return response;
    }

    public async ValueTask<T> GetUniqueAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var response = await _context.Set<T>().FindAsync(new object[] { id }, cancellationToken);
        _logger.LogInformation("{response} was retrieved", response);
        return response;
    }

    public ValueTask Update(T entity)
    {
        _context.Set<T>().Update(entity);
        _logger.LogInformation("{entity} was updated", entity);
        return ValueTask.CompletedTask;
    }
}
