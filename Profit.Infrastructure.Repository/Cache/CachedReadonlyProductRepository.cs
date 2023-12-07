namespace Profit.Infrastructure.Repository.Cache;

public sealed class CachedReadOnlyProductRepository : IReadOnlyProductRepository
{
    private readonly ITenantInfo _tenant;
    private readonly ICacheService _cacheService;
    private readonly IOptions<CacheOptions> _cacheOptions;
    private readonly IReadOnlyProductRepository _repo;
    private readonly ILogger<CachedReadOnlyProductRepository> _logger;

    public CachedReadOnlyProductRepository(
        ILogger<CachedReadOnlyProductRepository> logger,
        ICacheService cacheService,
        IOptions<CacheOptions> cacheOptions,
        ITenantInfo tenant,
        IReadOnlyProductRepository readOnlyProductRepo)
    {
        _repo = readOnlyProductRepo;
        _tenant = tenant;
        _cacheService = cacheService;
        _cacheOptions = cacheOptions;
        _logger = logger;
    }

    private string GetRedisKey(params string[] keys)
    {
        return $"{ICacheService.GetCustomKey(
            _tenant.TenantId.ToString(),
            nameof(Product))}:{ICacheService.GetCustomKey(keys)}";
    }

    public async ValueTask<int> CountAsync(CancellationToken cancellationToken = default)
    {
        var redisKey = GetRedisKey(nameof(CountAsync));

        var count = await _cacheService.GetAsync<int>(redisKey);

        if (count is 0)
        {
            _logger.LogInformation("Cache was not hit for {redisKey} on {sourceName}",
               redisKey,
               nameof(CachedReadOnlyProductRepository));

            count = await _repo.CountAsync(cancellationToken);
            await _cacheService.SetAsync(redisKey, count, TimeSpan.FromSeconds(_cacheOptions.Value.SecondsDuration));
        }
        else
        {
            _logger.LogInformation("Cache was hit for {redisKey} on {sourceName}",
                redisKey,
                nameof(CachedReadOnlyProductRepository));
        }

        return count;
    }

    public async ValueTask<bool> ExistsAsync(Product entity, CancellationToken cancellationToken = default)
    {
        var redisKey = GetRedisKey(entity.Id.ToString());
        var response = _cacheService.GetAsync<Product>(redisKey);

        if (response is not null)
        {
            _logger.LogInformation("Cache was hit for {redisKey} on {sourceName}",
                redisKey,
                nameof(CachedReadOnlyProductRepository));

            return true;
        }

        return await _repo.ExistsAsync(entity, cancellationToken);
    }

    public async ValueTask<EntityQueryResultPaginated<Product>> GetPaginatedAsync(BasePaginatedQuery paginatedQuery, CancellationToken cancellationToken = default)
    {
        var redisKey = GetRedisKey(
            nameof(GetPaginatedAsync),
            nameof(paginatedQuery.PageNumber),
            paginatedQuery.PageNumber.ToString(),
            nameof(paginatedQuery.ItemsPerPage),
            paginatedQuery.ItemsPerPage.ToString());

        var response = await _cacheService.GetAsync<EntityQueryResultPaginated<Product>>(redisKey);

        if (response is not null)
        {
            _logger.LogInformation("Cache was not hit for {redisKey} on {sourceName}",
                redisKey,
                nameof(CachedReadOnlyProductRepository));

            response = await _repo.GetPaginatedAsync(paginatedQuery, cancellationToken);
            await _cacheService.SetAsync(redisKey, response, TimeSpan.FromSeconds(_cacheOptions.Value.SecondsDuration));
        }
        else
        {
            _logger.LogInformation("Cache was hit for {redisKey} on {sourceName}",
                redisKey,
                nameof(CachedReadOnlyProductRepository));
        }

        return response;
    }

    public async ValueTask<Product> GetUniqueAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var redisKey = GetRedisKey(id.ToString());
        var Product = await _cacheService.GetAsync<Product>(redisKey);

        if (Product is null)
        {
            _logger.LogInformation("Cache was not hit for {redisKey} on {sourceName}",
                redisKey,
                nameof(CachedReadOnlyProductRepository));

            Product = await _repo.GetUniqueAsync(id, cancellationToken);
            await _cacheService.SetAsync(redisKey, Product, TimeSpan.FromSeconds(_cacheOptions.Value.SecondsDuration));
        }
        else
        {
            _logger.LogInformation("Cache was hit for {redisKey} on {sourceName}",
                redisKey,
                nameof(CachedReadOnlyProductRepository));
        }

        return Product;
    }

    public async ValueTask<EntityQueryResultPaginated<Product>> GetByPaginatedAsync(Expression<Func<Product, bool>> predicate, BasePaginatedQuery paginatedQuery, CancellationToken cancellationToken = default)
    {
        var result = await _repo.GetByPaginatedAsync(predicate, paginatedQuery, cancellationToken);
        return result;
    }

    public async ValueTask<int> CountByAsync(Expression<Func<Product, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await _repo.CountByAsync(predicate, cancellationToken);
    }

    public async ValueTask<Product> GetUniqueByAsync(Expression<Func<Product, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await _repo.GetUniqueByAsync(predicate, cancellationToken);
    }

    public async Task<decimal> GetProductCost(Guid productId, CancellationToken cancellationToken = default)
    {
        return await _repo.GetProductCost(productId, cancellationToken);
    }
}
