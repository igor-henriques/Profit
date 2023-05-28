namespace Profit.Infrastructure.Repository.Repositories.Base;

public abstract class ReadOnlyBaseRepository<TEntity, TDbContext> : IReadOnlyBaseRepository<TEntity>
    where TEntity : Entity<TEntity>
    where TDbContext : DbContext
{
    private readonly TDbContext _context;
    private readonly ILogger<ReadOnlyBaseRepository<TEntity, TDbContext>> _logger;

    public ReadOnlyBaseRepository(TDbContext context, ILogger<ReadOnlyBaseRepository<TEntity, TDbContext>> logger)
    {
        _context = context;
        _logger = logger;
    }

    public virtual async ValueTask<bool> Exists(TEntity entity, CancellationToken cancellationToken = default)
    {
        if (entity == null || entity == default)
        {
            return false;
        }

        var response = await _context
            .Set<TEntity>()
            .AsNoTracking()
            .AnyAsync(x => x.Id == entity.Id, cancellationToken);

        _logger.LogInformation("{methodName} from {sourceName} retrieved {response}",
            nameof(Exists),
            nameof(ReadOnlyBaseRepository<TEntity, TDbContext>),
            response);


        return response;
    }

    public virtual async ValueTask<bool> ExistsByAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
    {
        var response = await _context
            .Set<TEntity>()
            .AsNoTracking()
            .AnyAsync(predicate, cancellationToken);

        _logger.LogInformation("{methodName} from {sourceName} retrieved {response}",
            nameof(ExistsByAsync),
            nameof(ReadOnlyBaseRepository<TEntity, TDbContext>),
            response);

        return response;
    }

    public virtual async ValueTask<IEnumerable<TEntity>> GetManyAsync(CancellationToken cancellationToken = default)
    {
        var response = await _context
            .Set<TEntity>()
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        _logger.LogInformation("{methodName} from {sourceName} retrieved {response}",
            nameof(GetManyAsync),
            nameof(ReadOnlyBaseRepository<TEntity, TDbContext>),
            response);

        return response;
    }


    public virtual async ValueTask<IEnumerable<TEntity>> GetManyByAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
    {
        var response = await _context
            .Set<TEntity>()
            .AsNoTracking()
            .Where(predicate)
            .ToListAsync(cancellationToken);

        _logger.LogInformation("{methodName} from {sourceName} retrieved {response}",
            nameof(GetManyByAsync),
            nameof(ReadOnlyBaseRepository<TEntity, TDbContext>),
            response);

        return response;
    }

    public virtual async ValueTask<TEntity> GetUniqueAsync(Guid id, CancellationToken cancellationToken = default)
    {
        if (id == default)
        {
            _logger.LogInformation("{methodName} from {sourceName} retrieved {response}",
            nameof(GetUniqueAsync),
            nameof(ReadOnlyBaseRepository<TEntity, TDbContext>),
            "null");

            return null;
        }

        var response = await _context
            .Set<TEntity>()
            .AsNoTracking()
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync(cancellationToken);

        _logger.LogInformation("{methodName} from {sourceName} retrieved {response}",
            nameof(GetUniqueAsync),
            nameof(ReadOnlyBaseRepository<TEntity, TDbContext>),
            response);

        return response;
    }

    public virtual async ValueTask<TEntity> GetUniqueByAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
    {
        var response = await _context
            .Set<TEntity>()
            .AsNoTracking()
            .Where(predicate)
            .FirstOrDefaultAsync(cancellationToken);

        _logger.LogInformation("{methodName} from {sourceName} retrieved {response}",
            nameof(GetUniqueByAsync),
            nameof(ReadOnlyBaseRepository<TEntity, TDbContext>),
            response);

        return response;
    }

    public virtual async ValueTask<EntityQueryResultPaginated<TEntity>> GetByPaginated(
        Expression<Func<TEntity, bool>> predicate,
        int page,
        int pageSize,
        CancellationToken cancellationToken = default)
    {
        var response = await _context.Set<TEntity>()
            .AsNoTracking()
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
           nameof(ReadOnlyBaseRepository<TEntity, TDbContext>),
           paginatedResult);

        return paginatedResult;
    }

    public virtual async ValueTask<int> CountByAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
    {
        var response = await _context
            .Set<TEntity>()
            .AsNoTracking()
            .CountAsync(predicate, cancellationToken);

        _logger.LogInformation("{methodName} from {sourceName} retrieved {response}",
           nameof(CountByAsync),
           nameof(ReadOnlyBaseRepository<TEntity, TDbContext>),
           response);

        return response;
    }
}
