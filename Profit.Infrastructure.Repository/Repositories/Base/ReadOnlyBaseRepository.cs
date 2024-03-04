namespace Profit.Infrastructure.Repository.Repositories.Base;

public abstract class ReadOnlyBaseRepository<TEntity, TDbContext> : IReadOnlyBaseRepository<TEntity>
    where TEntity : Entity<TEntity>, IEntity
    where TDbContext : DbContext
{
    private readonly TDbContext _context;
    private readonly ILogger<ReadOnlyBaseRepository<TEntity, TDbContext>> _logger;

    public ReadOnlyBaseRepository(TDbContext context, ILogger<ReadOnlyBaseRepository<TEntity, TDbContext>> logger)
    {
        _context = context;
        _logger = logger;
    }

    public virtual async ValueTask<bool> ExistsAsync(TEntity entity, CancellationToken cancellationToken = default)
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
            nameof(ExistsAsync),
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

    public virtual async ValueTask<EntityQueryResultPaginated<TEntity>> GetByPaginatedAsync(
        Expression<Func<TEntity, bool>> predicate,
        BasePaginatedQuery basePaginated,
        CancellationToken cancellationToken = default)
    {
        if (basePaginated.PageNumber < 1 || basePaginated.ItemsPerPage <= 0)
        {
            _logger.LogInformation("{methodName} from {sourceName} retrieved {response} due invalid paginatedQuery.PageNumber or paginatedQuery.ItemsPerPage",
                nameof(GetByPaginatedAsync),
                nameof(ReadOnlyBaseRepository<TEntity, TDbContext>),
                "empty");

            return new EntityQueryResultPaginated<TEntity>()
            {
                Data = Enumerable.Empty<TEntity>().ToList(),
                PageNumber = basePaginated.PageNumber,
                ItemsPerPage = basePaginated.ItemsPerPage
            };
        }

        var response = await _context.Set<TEntity>()
            .AsNoTracking()
            .Where(predicate)
            .Skip((basePaginated.PageNumber - 1) * basePaginated.ItemsPerPage)
            .Take(basePaginated.ItemsPerPage)
            .ToListAsync(cancellationToken);

        var count = await CountAsync(cancellationToken);

        var paginatedResult = new EntityQueryResultPaginated<TEntity>()
        {
            Data = response,
            PageNumber = basePaginated.PageNumber,
            ItemsPerPage = basePaginated.ItemsPerPage,
            TotalCount = count,
            TotalPages = (int)Math.Ceiling(count / (double)basePaginated.ItemsPerPage)
        };

        _logger.LogInformation("{methodName} from {sourceName} retrieved {response}",
           nameof(GetByPaginatedAsync),
           nameof(ReadOnlyBaseRepository<TEntity, TDbContext>),
           paginatedResult);

        return paginatedResult;
    }

    public virtual async ValueTask<EntityQueryResultPaginated<TEntity>> GetPaginatedAsync(
        BasePaginatedQuery paginatedQuery,
        CancellationToken cancellationToken = default)
    {
        if (paginatedQuery.PageNumber < 1 || paginatedQuery.ItemsPerPage <= 0)
        {
            _logger.LogInformation("{methodName} from {sourceName} retrieved {response} due invalid paginatedQuery.PageNumber or paginatedQuery.ItemsPerPage",
                nameof(GetPaginatedAsync),
                nameof(ReadOnlyBaseRepository<TEntity, TDbContext>),
                "empty");

            return new EntityQueryResultPaginated<TEntity>()
            {
                Data = Enumerable.Empty<TEntity>().ToList(),
                PageNumber = paginatedQuery.PageNumber,
                ItemsPerPage = paginatedQuery.ItemsPerPage
            };
        }

        var response = await _context
            .Set<TEntity>()
            .AsNoTracking()
            .Skip((paginatedQuery.PageNumber - 1) * paginatedQuery.ItemsPerPage)
            .Take(paginatedQuery.ItemsPerPage)
            .ToListAsync(cancellationToken);

        var count = await CountAsync(cancellationToken);

        var paginatedResult = new EntityQueryResultPaginated<TEntity>()
        {
            Data = response,
            PageNumber = paginatedQuery.PageNumber,
            ItemsPerPage = paginatedQuery.ItemsPerPage,
            TotalCount = count,
            TotalPages = (int)Math.Ceiling(count / (double)paginatedQuery.ItemsPerPage)
        };

        _logger.LogInformation("{methodName} from {sourceName} retrieved {response}",
           nameof(GetPaginatedAsync),
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

    public virtual async ValueTask<int> CountAsync(CancellationToken cancellationToken = default)
    {
        var response = await _context
            .Set<TEntity>()
            .AsNoTracking()
            .CountAsync(cancellationToken);

        _logger.LogInformation("{methodName} from {sourceName} retrieved {response}",
           nameof(CountAsync),
           nameof(ReadOnlyBaseRepository<TEntity, TDbContext>),
           response);

        return response;
    }
}
