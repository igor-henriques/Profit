namespace Profit.Infrastructure.Repository.Cache;

internal sealed class RedisCachedProductRepository : IProductRepository
{
    private readonly IRedisCacheService _cacheService;
    private readonly ProductRepository _productRepository;

    public RedisCachedProductRepository(
        ProfitDbContext context,
        ILogger<UnitOfWork> logger,
        IRedisCacheService cacheService)
    {
        this._productRepository = new ProductRepository(context, logger);
        this._cacheService = cacheService;
    }

    public async ValueTask Add(Product entity, CancellationToken cancellationToken = default)
    {
        await _cacheService.SetAsync(entity.Id.ToString(), entity, TimeSpan.FromHours(1));
        await _productRepository.Add(entity, cancellationToken);
    }

    public async Task BulkAdd(IEnumerable<Product> ingredients)
    {
        foreach (var ingredient in ingredients)
        {
            await _cacheService.SetAsync(ingredient.Id.ToString(), ingredient, TimeSpan.FromHours(1));
        }

        _productRepository.BulkAdd(ingredients);
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

    public ValueTask<IEnumerable<Product>> GetManyAsync(CancellationToken cancellationToken = default)
    {
        return _productRepository.GetManyAsync(cancellationToken);
    }

    public async ValueTask<Product> GetUniqueAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var product = await _cacheService.GetAsync<Product>(id.ToString());

        if (product is null)
        {
            product = await _productRepository.GetUniqueAsync(id, cancellationToken);
            await _cacheService.SetAsync(id.ToString(), product, TimeSpan.FromHours(1));
        }

        return product;
    }

    public async ValueTask Update(Product entity)
    {
        var product = await _cacheService.GetAsync<Product>(entity.Id.ToString());

        if (product is not null)
        {
            await _cacheService.SetAsync(product.Id.ToString(), entity, TimeSpan.FromHours(1));
        }

        await _productRepository.Update(entity);
    }
}
