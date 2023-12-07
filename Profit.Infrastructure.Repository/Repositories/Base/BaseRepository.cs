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
        var entityExists = await ExistsAsync(entity, cancellationToken);

        if (entityExists)
        {
            throw new InvalidOperationException($"{typeof(TEntity).Name} already exists");
        }

        _context.Set<TEntity>().Add(entity);

        _logger.LogInformation("{methodName} from {sourceName}: {entity} was added, but not yet commited: {value}",
           nameof(Add),
           nameof(BaseRepository<TEntity, TDbContext>),
           nameof(TEntity),
           entity);
    }
    private async ValueTask<bool> ExistsAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        var response = await _context
            .Set<TEntity>()
            .AnyAsync(x => x.Id == entity.Id, cancellationToken);

        _logger.LogInformation("{methodName} from {sourceName} retrieved {response}",
          nameof(ExistsAsync),
          nameof(BaseRepository<TEntity, TDbContext>),
          response);

        return response;
    }

    public virtual async ValueTask<IEnumerable<TEntity>> GetPaginatedByAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
    {
        var response = await _context
            .Set<TEntity>()
            .Where(predicate)
            .ToListAsync(cancellationToken);

        _logger.LogInformation("{methodName} from {sourceName} retrieved {response}",
           nameof(GetPaginatedByAsync),
           nameof(BaseRepository<TEntity, TDbContext>),
           response);

        return response;
    }

    public virtual void BulkAdd(IEnumerable<TEntity> entities)
    {
        _context.Set<TEntity>()
                .AddRange(entities);

        _logger.LogInformation("{methodName} from {sourceName}: {entityCount} was added, but not yet commited",
           nameof(BulkAdd),
           nameof(BaseRepository<TEntity, TDbContext>),
           entities.Count());
    }

    /// <summary>
    /// Make sure to keep the method deleting, even tho the project is using soft delete.
    /// In the <see cref="SoftDeleteInterceptor"/> we are checking if the entity is soft deletable, and if it is, we are marking it as deleted.
    /// </summary>
    /// <param name="entity"></param>
    public virtual void Delete(TEntity entity)
    {
        _context.Set<TEntity>().Remove(entity);

        _logger.LogInformation("{methodName} from {sourceName}: {entity} was marked to removal, but not yet commited: {value}",
           nameof(Delete),
           nameof(BaseRepository<TEntity, TDbContext>),
           nameof(TEntity),
           entity);
    }

    public virtual async ValueTask<IEnumerable<TEntity>> GetPaginatedAsync(CancellationToken cancellationToken = default)
    {
        var response = await _context.Set<TEntity>()
                                     .ToListAsync(cancellationToken);

        _logger.LogInformation("{methodName} from {sourceName} retrieved {response}",
          nameof(GetPaginatedAsync),
          nameof(BaseRepository<TEntity, TDbContext>),
          response);

        return response;
    }

    public virtual async ValueTask<TEntity> GetUniqueAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var response = await _context
            .Set<TEntity>()
            .FindAsync(new object[] { id }, cancellationToken);

        _logger.LogInformation("{methodName} from {sourceName} retrieved {response}",
          nameof(GetUniqueAsync),
          nameof(BaseRepository<TEntity, TDbContext>),
          response);

        return response;
    }

    public virtual void Update(TEntity entity)
    {
        entity.UpdatedAt = DateTime.Now;

        _context.Set<TEntity>()
                .Update(entity);

        _logger.LogInformation("{methodName} from {sourceName}: {entity} was marked to update, but not yet commited: {value}",
           nameof(Update),
           nameof(BaseRepository<TEntity, TDbContext>),
           nameof(TEntity),
           entity);
    }
}
