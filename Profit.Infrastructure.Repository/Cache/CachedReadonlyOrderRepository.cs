namespace Profit.Infrastructure.Repository.Cache;

public sealed class CachedReadOnlyOrderRepository : IReadOnlyOrderRepository
{
    private readonly ITenantInfo _tenant;
    private readonly ICacheService _cacheService;
    private readonly IOptions<CacheOptions> _cacheOptions;
    private readonly IReadOnlyOrderRepository _repo;
    private readonly ILogger<UnitOfWork> _logger;

    public CachedReadOnlyOrderRepository(
        ILogger<UnitOfWork> logger,
        ICacheService cacheService,
        IOptions<CacheOptions> cacheOptions,
        ITenantInfo tenant,
        IReadOnlyOrderRepository readOnlyOrderRepo)
    {
        _repo = readOnlyOrderRepo;
        _tenant = tenant;
        _cacheService = cacheService;
        _cacheOptions = cacheOptions;
        _logger = logger;
    }

    private string GetRedisKey(params string[] keys)
    {
        return $"{ICacheService.GetCustomKey(
            _tenant.TenantId.ToString(),
            nameof(Order))}:{ICacheService.GetCustomKey(keys)}";
    }

    public async ValueTask<int> CountAsync(CancellationToken cancellationToken = default)
    {
        var redisKey = GetRedisKey(nameof(CountAsync));

        var count = await _cacheService.GetAsync<int>(redisKey);

        if (count is 0)
        {
            _logger.LogInformation("Cache was not hit for {redisKey} on {sourceName}",
               redisKey,
               nameof(CachedReadOnlyOrderRepository));

            count = await _repo.CountAsync(cancellationToken);
            await _cacheService.SetAsync(redisKey, count, TimeSpan.FromSeconds(_cacheOptions.Value.SecondsDuration));
        }
        else
        {
            _logger.LogInformation("Cache was hit for {redisKey} on {sourceName}",
                redisKey,
                nameof(CachedReadOnlyOrderRepository));
        }

        return count;
    }

    public async ValueTask<bool> ExistsAsync(Order entity, CancellationToken cancellationToken = default)
    {
        var redisKey = GetRedisKey(entity.Id.ToString());
        var response = _cacheService.GetAsync<Order>(redisKey);

        if (response is not null)
        {
            _logger.LogInformation("Cache was hit for {redisKey} on {sourceName}",
                redisKey,
                nameof(CachedReadOnlyOrderRepository));

            return true;
        }

        return await _repo.ExistsAsync(entity, cancellationToken);
    }

    public async ValueTask<EntityQueryResultPaginated<Order>> GetPaginatedAsync(BasePaginatedQuery paginatedQuery, CancellationToken cancellationToken = default)
    {
        var redisKey = GetRedisKey(nameof(GetPaginatedAsync));
        var response = await _cacheService.GetAsync<EntityQueryResultPaginated<Order>>(redisKey);

        if (response is not null)
        {
            _logger.LogInformation("Cache was not hit for {redisKey} on {sourceName}",
                redisKey,
                nameof(CachedReadOnlyOrderRepository));

            response = await _repo.GetPaginatedAsync(paginatedQuery, cancellationToken);
            await _cacheService.SetAsync(redisKey, response, TimeSpan.FromSeconds(_cacheOptions.Value.SecondsDuration));
        }
        else
        {
            _logger.LogInformation("Cache was hit for {redisKey} on {sourceName}",
                redisKey,
                nameof(CachedReadOnlyOrderRepository));
        }

        return response;
    }

    public async ValueTask<Order> GetUniqueAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var redisKey = GetRedisKey(id.ToString());
        var Order = await _cacheService.GetAsync<Order>(redisKey);

        if (Order is null)
        {
            _logger.LogInformation("Cache was not hit for {redisKey} on {sourceName}",
                redisKey,
                nameof(CachedReadOnlyOrderRepository));

            Order = await _repo.GetUniqueAsync(id, cancellationToken);
            await _cacheService.SetAsync(redisKey, Order, TimeSpan.FromSeconds(_cacheOptions.Value.SecondsDuration));
        }
        else
        {
            _logger.LogInformation("Cache was hit for {redisKey} on {sourceName}",
                redisKey,
                nameof(CachedReadOnlyOrderRepository));
        }

        return Order;
    }

    public async ValueTask<EntityQueryResultPaginated<Order>> GetByPaginatedAsync(Expression<Func<Order, bool>> predicate, BasePaginatedQuery paginatedQuery, CancellationToken cancellationToken = default)
    {
        var result = await _repo.GetByPaginatedAsync(predicate, paginatedQuery, cancellationToken);

        int totalCount = await CountAsync(cancellationToken);
        var totalPages = (int)Math.Ceiling(totalCount / (double)paginatedQuery.ItemsPerPage);

        result.TotalPages = totalPages;
        result.TotalCount = totalCount;

        return result;
    }

    public async ValueTask<int> CountByAsync(Expression<Func<Order, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await _repo.CountByAsync(predicate, cancellationToken);
    }

    public async ValueTask<Order> GetUniqueByAsync(Expression<Func<Order, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await _repo.GetUniqueByAsync(predicate, cancellationToken);
    }
}
