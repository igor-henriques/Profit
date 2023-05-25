namespace Profit.Infrastructure.Repository.Cache;

internal sealed class RedisCachedProductRepository : IProductRepository
{
    private readonly IRedisCacheService _cacheService;
    private readonly ProductRepository _productRepository;
    private const string REDIS_PRODUCT_PREFIX = "profit:product:";
    private readonly long _cacheExpirationInSeconds;

    public RedisCachedProductRepository(
        ProfitDbContext context,
        ILogger<UnitOfWork> logger,
        IRedisCacheService cacheService,
        IConfiguration configuration)
    {
        this._productRepository = new ProductRepository(context, logger);
        this._cacheService = cacheService;
        this._cacheExpirationInSeconds = configuration.GetValue<long>("CacheSecondsDuration");
    }

    private static string GetRedisKey(Guid id)
    {
        return $"{REDIS_PRODUCT_PREFIX}{id}";
    }

    public async ValueTask Add(Product entity, CancellationToken cancellationToken = default)
    {
        await _productRepository.Add(entity, cancellationToken);
    }

    public void BulkAdd(IEnumerable<Product> products)
    {
        _productRepository.BulkAdd(products);
    }

    public async ValueTask<int> CountAsync(CancellationToken cancellationToken = default)
    {
        return await _productRepository.CountAsync(cancellationToken);
    }

    public void Delete(Product entity)
    {
        _cacheService.Remove(entity.Id.ToString());
        _productRepository.Delete(entity);
    }

    public async ValueTask<bool> Exists(Product entity, CancellationToken cancellationToken = default)
    {
        var existsOnCache = _cacheService.Exists(entity.Id.ToString());

        if (!existsOnCache)
        {
            return await _productRepository.Exists(entity, cancellationToken);
        }

        return existsOnCache;
    }

    public async ValueTask<IEnumerable<Product>> GetManyAsync(CancellationToken cancellationToken = default)
    {
        var response = await _cacheService.GetAllKeys<Product>(REDIS_PRODUCT_PREFIX);

        if (!response.Any())
        {
            response = await _productRepository.GetManyAsync(cancellationToken);

            foreach (var item in response)
            {
                await _cacheService.SetAsync(GetRedisKey(item.Id), item, TimeSpan.FromSeconds(_cacheExpirationInSeconds));
            }
        }

        return response;
    }

    public async ValueTask<Product> GetUniqueAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var product = await _cacheService.GetAsync<Product>(GetRedisKey(id));

        if (product is null)
        {
            product = await _productRepository.GetUniqueAsync(id, cancellationToken);
            await _cacheService.SetAsync(GetRedisKey(id), product, TimeSpan.FromSeconds(_cacheExpirationInSeconds));
        }

        return product;
    }

    public void Update(Product entity)
    {
        _productRepository.Update(entity);
    }

    public async Task<IEnumerable<Product>> GetProductsByRecipeId(Guid recipeId, CancellationToken cancellationToken = default)
    {
        return await _productRepository.GetProductsByRecipeId(recipeId, cancellationToken);
    }
}
