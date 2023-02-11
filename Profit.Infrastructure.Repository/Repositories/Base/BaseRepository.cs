namespace Profit.Infrastructure.Repository.Repositories.Base;

internal abstract class BaseRepository<TEntity, TDbContext> : IBaseRepository<TEntity>
    where TEntity : Entity<TEntity>
    where TDbContext : DbContext
{
    private readonly TDbContext _context;
    private readonly ILogger<UnitOfWork> _logger;

    public BaseRepository(TDbContext context, ILogger<UnitOfWork> logger)
    {
        _context = context;
        _logger = logger;
    }

    public virtual async ValueTask Add(TEntity entity, CancellationToken cancellationToken = default)
    {
        var entityExists = await Exists(entity, cancellationToken);

        if (entityExists)
        {
            throw new InvalidOperationException("Entity already exists");
        }

        _context.Set<TEntity>().Add(entity);
        _logger.LogInformation("{entity} was added", entity);
    }

    public virtual void BulkAdd(IEnumerable<TEntity> entities)
    {
        _context.Set<TEntity>().AddRange(entities);
        _logger.LogInformation("{entities} records were added", entities.Count());
    }

    public virtual async ValueTask<int> CountAsync(CancellationToken cancellationToken = default)
    {
        var response = await _context.Set<TEntity>().CountAsync(cancellationToken);
        _logger.LogInformation("{response} records were counted", response);
        return response;
    }

    public virtual void Delete(TEntity entity)
    {
        _context.Set<TEntity>().Remove(entity);
        _logger.LogInformation("{entity} removed from database", entity);
    }

    public virtual async ValueTask<bool> Exists(TEntity entity, CancellationToken cancellationToken = default)
    {
        return await _context.Set<TEntity>().AnyAsync(x => x.Id == entity.Id, cancellationToken);
    }

    public virtual async ValueTask<IEnumerable<TEntity>> GetManyAsync(CancellationToken cancellationToken = default)
    {
        var response = await _context.Set<TEntity>().ToListAsync(cancellationToken);
        _logger.LogInformation("{response} records were retrieved", response.Count);
        return response;
    }

    public virtual async ValueTask<TEntity> GetUniqueAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var response = await _context.Set<TEntity>().FindAsync(new object[] { id }, cancellationToken);
        _logger.LogInformation("{response} was retrieved", response);
        return response;
    }

    public virtual void Update(TEntity entity)
    {
        _context.Set<TEntity>().Update(entity);
        _logger.LogInformation("{entity} was updated", entity);
    }
}
