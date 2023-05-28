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

        _logger.LogInformation("{methodName} from {sourceName}: {entity} was added, but not commited: {value}",
           nameof(Add),
           nameof(BaseRepository<TEntity, TDbContext>),
           nameof(TEntity),
           entity);        
    }

    public virtual async ValueTask<IEnumerable<TEntity>> GetManyByAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
    {
        var response = await _context
            .Set<TEntity>()
            .Where(predicate)
            .ToListAsync(cancellationToken);

        _logger.LogInformation("{methodName} from {sourceName} retrieved {response}",
           nameof(GetManyByAsync),
           nameof(BaseRepository<TEntity, TDbContext>),
           response);

        return response;
    }

    public virtual void BulkAdd(IEnumerable<TEntity> entities)
    {
        _context.Set<TEntity>()
                .AddRange(entities);

        _logger.LogInformation("{methodName} from {sourceName}: {entityCount} was added, but not commited",
           nameof(BulkAdd),
           nameof(BaseRepository<TEntity, TDbContext>),
           entities.Count());
    }

    public virtual async ValueTask<int> CountAsync(CancellationToken cancellationToken = default)
    {
        var response = await _context.Set<TEntity>()
                                     .CountAsync(cancellationToken);

        _logger.LogInformation("{methodName} from {sourceName} retrieved {response}",
          nameof(CountAsync),
          nameof(BaseRepository<TEntity, TDbContext>),
          response);

        return response;
    }

    public virtual void Delete(TEntity entity)
    {
        _context.Set<TEntity>().Remove(entity);

        _logger.LogInformation("{methodName} from {sourceName}: {entity} was marked to removal, but not commited: {value}",
           nameof(Delete),
           nameof(BaseRepository<TEntity, TDbContext>),
           nameof(TEntity),
           entity);
    }

    public virtual async ValueTask<bool> ExistsAsync(TEntity entity, CancellationToken cancellationToken = default)
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

    public virtual async ValueTask<IEnumerable<TEntity>> GetManyAsync(CancellationToken cancellationToken = default)
    {
        var response = await _context.Set<TEntity>()
                                     .ToListAsync(cancellationToken);

        _logger.LogInformation("{methodName} from {sourceName} retrieved {response}",
          nameof(GetManyAsync),
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
        _context.Set<TEntity>()
                .Update(entity);

        _logger.LogInformation("{methodName} from {sourceName}: {entity} was marked to update, but not commited: {value}",
           nameof(Update),
           nameof(BaseRepository<TEntity, TDbContext>),
           nameof(TEntity),
           entity);
    }

    public virtual async ValueTask<EntityQueryResultPaginated<TEntity>> GetByPaginated(
        Expression<Func<TEntity, bool>> predicate,
        int page,
        int pageSize,
        CancellationToken cancellationToken = default)
    {
        var response = await _context.Set<TEntity>()
            .Where(predicate)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);
        
        var paginatedResult = new EntityQueryResultPaginated<TEntity>()
        {
            Data = response,
            PageNumber = page,
            PageSize = pageSize
        };

        _logger.LogInformation("{methodName} from {sourceName} retrieved {response}",
          nameof(GetByPaginated),
          nameof(BaseRepository<TEntity, TDbContext>),
          paginatedResult);

        return paginatedResult;
    }

    public virtual async ValueTask<int> CountByAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
    {
        var response = await _context.Set<TEntity>()
                                     .CountAsync(predicate, cancellationToken);

        _logger.LogInformation("{methodName} from {sourceName} retrieved {response}",
         nameof(CountByAsync),
         nameof(BaseRepository<TEntity, TDbContext>),
         response);

        return response;
    }
}
