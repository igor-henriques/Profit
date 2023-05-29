namespace Profit.Infrastructure.Repository.Cache;

internal sealed class RedisCachedProductRepository : IProductRepository
{
    private readonly ITenantInfo _tenant;
    private readonly IRedisCacheService _cacheService;
    private readonly ProductRepository _repo;
    private const string REDIS_PREFIX = "profit:product:";
    private readonly long _cacheExpirationInSeconds;
    private readonly ILogger<UnitOfWork> _logger;
    private readonly IReadOnlyProductRepository _readOnlyRepo;

    public RedisCachedProductRepository(
        ProfitDbContext context,
        ILogger<UnitOfWork> logger,
        IRedisCacheService cacheService,
        IOptions<CacheOptions> cacheOptions,
        ITenantInfo tenant)
    {
        _repo = new ProductRepository(context, logger);
        _cacheService = cacheService;
        _cacheExpirationInSeconds = cacheOptions.Value.SecondsDuration;
        _tenant = tenant;
        _logger = logger;
    }

    private string GetRedisKey(Guid id)
    {
        return IRedisCacheService.GetCustomKey(
            _tenant.TenantId.FormatTenantToSchema(),
            REDIS_PREFIX,
            id.ToString());
    }

    public async ValueTask Add(Product entity, CancellationToken cancellationToken = default)
    {
        await _repo.Add(entity, cancellationToken);
    }

    public void BulkAdd(IEnumerable<Product> products)
    {
        _repo.BulkAdd(products);
    }

    public async ValueTask<int> CountAsync(CancellationToken cancellationToken = default)
    {
        var redisKey = IRedisCacheService.GetCustomKey(
            _tenant.TenantId.FormatTenantToSchema(),
            nameof(Product),
            nameof(CountAsync));

        var count = await _cacheService.GetAsync<int>(redisKey);

        if (count is 0)
        {
            count = await _readOnlyRepo.CountByAsync(x => true, cancellationToken);
            await _cacheService.SetAsync(redisKey, count, TimeSpan.FromSeconds(_cacheExpirationInSeconds));
        }
        else
        {
            _logger.LogInformation("Cache was hit for {methodName} on {sourceName}",
                nameof(CountAsync),
                nameof(RedisCachedProductRepository));
        }

        return count;
    }

    public void Delete(Product entity)
    {
        _cacheService.Remove(entity.Id.ToString());
        _repo.Delete(entity);
    }

    public async ValueTask<bool> ExistsAsync(Product entity, CancellationToken cancellationToken = default)
    {
        var existsOnCache = _cacheService.Exists(entity.Id.ToString());

        if (!existsOnCache)
        {
            return await _readOnlyRepo.ExistsAsync(entity, cancellationToken);
        }
        else
        {
            _logger.LogInformation("Cache was hit for {methodName} on {sourceName}",
                nameof(ExistsAsync),
                nameof(RedisCachedRecipeRepository));
        }

        return existsOnCache;
    }

    public async ValueTask<IEnumerable<Product>> GetManyAsync(CancellationToken cancellationToken = default)
    {
        var response = await _cacheService.GetAllKeys<Product>(REDIS_PREFIX);

        if (!response.Any())
        {
            response = await _readOnlyRepo.GetManyAsync(cancellationToken);

            foreach (var item in response)
            {
                await _cacheService.SetAsync(GetRedisKey(item.Id), item, TimeSpan.FromSeconds(_cacheExpirationInSeconds));
            }
        }
        else
        {
            _logger.LogInformation("Cache was hit for {methodName} on {sourceName}",
                nameof(GetManyAsync),
                nameof(RedisCachedRecipeRepository));
        }

        return response;
    }

    public async ValueTask<Product> GetUniqueAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var product = await _cacheService.GetAsync<Product>(GetRedisKey(id));

        if (product is null)
        {
            product = await _readOnlyRepo.GetUniqueAsync(id, cancellationToken);
            await _cacheService.SetAsync(GetRedisKey(id), product, TimeSpan.FromSeconds(_cacheExpirationInSeconds));
        }
        else
        {
            _logger.LogInformation("Cache was hit for {methodName} on {sourceName}",
                nameof(GetUniqueAsync),
                nameof(RedisCachedRecipeRepository));
        }

        return product;
    }

    public void Update(Product entity)
    {
        _repo.Update(entity);
    }

    public async Task<IEnumerable<Product>> GetProductsByRecipeId(Guid recipeId, CancellationToken cancellationToken = default)
    {
        return await _repo.GetProductsByRecipeId(recipeId, cancellationToken);
    }

    public async Task<decimal> GetProductCost(Guid productId, CancellationToken cancellationToken = default)
    {
        var specificRedisKey = $"{nameof(GetProductCost)}{productId}".ToLower();
        var productCost = await _cacheService.GetAsync<decimal>(specificRedisKey);

        if (productCost == default)
        {
            productCost = await _readOnlyRepo.GetProductCost(productId, cancellationToken);
            await _cacheService.SetAsync(specificRedisKey, productCost, TimeSpan.FromSeconds(_cacheExpirationInSeconds));
        }
        else
        {
            _logger.LogInformation("Cache was hit for {methodName} on {sourceName}",
                nameof(GetProductCost),
                nameof(RedisCachedRecipeRepository));
        }

        return productCost;
    }

    public async ValueTask<IEnumerable<Product>> GetManyByAsync(Expression<Func<Product, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await _readOnlyRepo.GetManyByAsync(predicate, cancellationToken);
    }

    public async ValueTask<EntityQueryResultPaginated<Product>> GetByPaginated(Expression<Func<Product, bool>> predicate, int page, int pageSize, CancellationToken cancellationToken = default)
    {
        var result = await _readOnlyRepo.GetByPaginated(predicate, page, pageSize, cancellationToken);

        int totalCount = await CountAsync(cancellationToken);
        var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

        result.TotalPages = totalPages;
        result.TotalCount = totalCount;

        return result;
    }

    public async ValueTask<int> CountByAsync(Expression<Func<Product, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await _readOnlyRepo.CountByAsync(predicate, cancellationToken);
    }
}
