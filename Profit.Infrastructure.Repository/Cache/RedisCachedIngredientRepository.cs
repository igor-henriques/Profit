namespace Profit.Infrastructure.Repository.Cache;

internal sealed class RedisCachedIngredientRepository : IIngredientRepository
{
    private readonly ITenantInfo _tenant;
    private readonly IRedisCacheService _cacheService;
    private readonly IngredientRepository _repo;
    private const string REDIS_PREFIX = "profit:ingredient:";
    private readonly long _cacheExpirationInSeconds;
    private readonly ILogger<UnitOfWork> _logger;

    public RedisCachedIngredientRepository(
        ProfitDbContext context,
        ILogger<UnitOfWork> logger,
        IRedisCacheService cacheService,
        IConfiguration configuration,
        ITenantInfo tenant)
    {
        _repo = new IngredientRepository(context, logger);
        _tenant = tenant;
        _cacheService = cacheService;
        _cacheExpirationInSeconds = configuration.GetValue<long>("CacheSecondsDuration");
        _logger = logger;
    }

    private string GetRedisKey(Guid id)
    {
        return IRedisCacheService.GetCustomKey(
            _tenant.TenantId.FormatTenantToSchema(),
            REDIS_PREFIX,
            id.ToString());
    }

    public async ValueTask Add(Ingredient entity, CancellationToken cancellationToken = default)
    {
        await _repo.Add(entity, cancellationToken);
    }

    public void BulkAdd(IEnumerable<Ingredient> ingredients)
    {
        _repo.BulkAdd(ingredients);
    }

    public async ValueTask<int> CountAsync(CancellationToken cancellationToken = default)
    {
        var redisKey = IRedisCacheService.GetCustomKey(
            _tenant.TenantId.FormatTenantToSchema(),
            nameof(Ingredient),
            nameof(CountAsync));

        var count = await _cacheService.GetAsync<int>(redisKey);

        if (count is 0)
        {
            count = await _repo.CountAsync(cancellationToken);
            await _cacheService.SetAsync(redisKey, count, TimeSpan.FromSeconds(_cacheExpirationInSeconds));
        }
        else
        {
            _logger.LogInformation("Cache was hit for {methodName} on {sourceName}",
                nameof(CountAsync),
                nameof(RedisCachedIngredientRepository));
        }

        return count;
    }

    public void Delete(Ingredient entity)
    {
        _cacheService.Remove(entity.Id.ToString());
        _repo.Delete(entity);
    }

    public async ValueTask<bool> Exists(Ingredient entity, CancellationToken cancellationToken = default)
    {
        return await _repo.Exists(entity, cancellationToken);
    }

    public async ValueTask<IEnumerable<Ingredient>> GetManyAsync(CancellationToken cancellationToken = default)
    {
        var response = await _cacheService.GetAllKeys<Ingredient>(REDIS_PREFIX);

        if (!response.Any())
        {
            response = await _repo.GetManyAsync(cancellationToken);

            foreach (var item in response)
            {
                await _cacheService.SetAsync(GetRedisKey(item.Id), item, TimeSpan.FromSeconds(_cacheExpirationInSeconds));
            }
        }
        else
        {
            _logger.LogInformation("Cache was hit for {methodName} on {sourceName}",
                nameof(GetManyAsync),
                nameof(RedisCachedIngredientRepository));
        }

        return response;
    }

    public async ValueTask<Ingredient> GetUniqueAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var ingredient = await _cacheService.GetAsync<Ingredient>(GetRedisKey(id));

        if (ingredient is null)
        {
            ingredient = await _repo.GetUniqueAsync(id, cancellationToken);
            await _cacheService.SetAsync(GetRedisKey(id), ingredient, TimeSpan.FromSeconds(_cacheExpirationInSeconds));
        }
        else
        {
            _logger.LogInformation("Cache was hit for {methodName} on {sourceName}",
                nameof(GetUniqueAsync),
                nameof(RedisCachedIngredientRepository));
        }

        return ingredient;
    }

    public void Update(Ingredient entity)
    {
        _repo.Update(entity);
    }

    public async ValueTask<IEnumerable<Ingredient>> GetManyByAsync(Expression<Func<Ingredient, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await _repo.GetManyByAsync(predicate, cancellationToken);
    }

    public async ValueTask<EntityQueryResultPaginated<Ingredient>> GetByPaginated(Expression<Func<Ingredient, bool>> predicate, int page, int pageSize, CancellationToken cancellationToken = default)
    {
        var result = await _repo.GetByPaginated(predicate, page, pageSize, cancellationToken);

        int totalCount = await CountAsync(cancellationToken);
        var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

        result.TotalPages = totalPages;
        result.TotalCount = totalCount;

        return result;
    }

    public async ValueTask<int> CountByAsync(Expression<Func<Ingredient, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await _repo.CountByAsync(predicate, cancellationToken);
    }
}
