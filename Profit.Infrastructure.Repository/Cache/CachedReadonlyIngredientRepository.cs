namespace Profit.Infrastructure.Repository.Cache;

public sealed class CachedReadonlyIngredientRepository : IReadOnlyIngredientRepository
{
    private readonly ITenantInfo _tenant;
    private readonly ICacheService _cacheService;
    private readonly IOptions<CacheOptions> _cacheOptions;
    private readonly IReadOnlyIngredientRepository _repo;
    private readonly ILogger<UnitOfWork> _logger;

    public CachedReadonlyIngredientRepository(
        ILogger<UnitOfWork> logger,
        ICacheService cacheService,
        IOptions<CacheOptions> cacheOptions,
        ITenantInfo tenant,
        IReadOnlyIngredientRepository readOnlyIngredientRepo)
    {
        _repo = readOnlyIngredientRepo;
        _tenant = tenant;
        _cacheService = cacheService;
        _cacheOptions = cacheOptions;
        _logger = logger;
    }

    private string GetRedisKey(params string[] keys)
    {
        return $"{ICacheService.GetCustomKey(
            _tenant.TenantId.ToString(),
            nameof(Ingredient))}:{ICacheService.GetCustomKey(keys)}";
    }

    public async ValueTask<int> CountAsync(CancellationToken cancellationToken = default)
    {
        var redisKey = GetRedisKey(nameof(CountAsync));

        var count = await _cacheService.GetAsync<int>(redisKey);

        if (count is 0)
        {
            _logger.LogInformation("Cache was not hit for {redisKey} on {sourceName}",
               redisKey,
               nameof(CachedReadonlyIngredientRepository));

            count = await _repo.CountAsync(cancellationToken);
            await _cacheService.SetAsync(redisKey, count, TimeSpan.FromSeconds(_cacheOptions.Value.SecondsDuration));
        }
        else
        {
            _logger.LogInformation("Cache was hit for {redisKey} on {sourceName}",
                redisKey,
                nameof(CachedReadonlyIngredientRepository));
        }

        return count;
    }

    public async ValueTask<bool> ExistsAsync(Ingredient entity, CancellationToken cancellationToken = default)
    {
        var redisKey = GetRedisKey(entity.Id.ToString());
        var response = _cacheService.GetAsync<Ingredient>(redisKey);

        if (response is not null)
        {
            _logger.LogInformation("Cache was hit for {redisKey} on {sourceName}",
                redisKey,
                nameof(CachedReadonlyIngredientRepository));

            return true;
        }

        return await _repo.ExistsAsync(entity, cancellationToken);
    }

    public async ValueTask<IEnumerable<Ingredient>> GetManyAsync(CancellationToken cancellationToken = default)
    {
        var redisKey = GetRedisKey(nameof(GetManyAsync));
        var response = await _cacheService.GetAsync<IEnumerable<Ingredient>>(redisKey);

        if (!response?.Any() ?? true)
        {
            _logger.LogInformation("Cache was not hit for {redisKey} on {sourceName}",
                redisKey,
                nameof(CachedReadonlyIngredientRepository));

            response = await _repo.GetManyAsync(cancellationToken);
            await _cacheService.SetAsync(redisKey, response, TimeSpan.FromSeconds(_cacheOptions.Value.SecondsDuration));
        }
        else
        {
            _logger.LogInformation("Cache was hit for {redisKey} on {sourceName}",
                redisKey,
                nameof(CachedReadonlyIngredientRepository));
        }

        return response;
    }

    public async ValueTask<Ingredient> GetUniqueAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var redisKey = GetRedisKey(id.ToString());
        var ingredient = await _cacheService.GetAsync<Ingredient>(redisKey);

        if (ingredient is null)
        {
            _logger.LogInformation("Cache was not hit for {redisKey} on {sourceName}",
                redisKey,
                nameof(CachedReadonlyIngredientRepository));

            ingredient = await _repo.GetUniqueAsync(id, cancellationToken);
            await _cacheService.SetAsync(redisKey, ingredient, TimeSpan.FromSeconds(_cacheOptions.Value.SecondsDuration));
        }
        else
        {
            _logger.LogInformation("Cache was hit for {redisKey} on {sourceName}",
                redisKey,
                nameof(CachedReadonlyIngredientRepository));
        }

        return ingredient;
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

    public async ValueTask<Ingredient> GetUniqueByAsync(Expression<Func<Ingredient, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await _repo.GetUniqueByAsync(predicate, cancellationToken);
    }
}
