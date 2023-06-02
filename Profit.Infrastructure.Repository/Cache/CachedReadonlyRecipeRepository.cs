namespace Profit.Infrastructure.Repository.Cache;

public sealed class CachedReadonlyRecipeRepository : IReadOnlyRecipeRepository
{
    private readonly ITenantInfo _tenant;
    private readonly ICacheService _cacheService;
    private readonly IOptions<CacheOptions> _cacheOptions;
    private readonly IReadOnlyRecipeRepository _repo;
    private readonly ILogger<UnitOfWork> _logger;

    public CachedReadonlyRecipeRepository(
        ILogger<UnitOfWork> logger,
        ICacheService cacheService,
        IOptions<CacheOptions> cacheOptions,
        ITenantInfo tenant,
        IReadOnlyRecipeRepository readOnlyRecipeRepo)
    {
        _repo = readOnlyRecipeRepo;
        _tenant = tenant;
        _cacheService = cacheService;
        _cacheOptions = cacheOptions;
        _logger = logger;
    }

    private string GetRedisKey(params string[] keys)
    {
        return $"{ICacheService.GetCustomKey(
            _tenant.TenantId.ToString(),
            nameof(Recipe))}:{ICacheService.GetCustomKey(keys)}";
    }

    public async ValueTask<int> CountAsync(CancellationToken cancellationToken = default)
    {
        var redisKey = GetRedisKey(nameof(CountAsync));

        var count = await _cacheService.GetAsync<int>(redisKey);

        if (count is 0)
        {
            _logger.LogInformation("Cache was not hit for {redisKey} on {sourceName}",
               redisKey,
               nameof(CachedReadonlyRecipeRepository));

            count = await _repo.CountAsync(cancellationToken);
            await _cacheService.SetAsync(redisKey, count, TimeSpan.FromSeconds(_cacheOptions.Value.SecondsDuration));
        }
        else
        {
            _logger.LogInformation("Cache was hit for {redisKey} on {sourceName}",
                redisKey,
                nameof(CachedReadonlyRecipeRepository));
        }

        return count;
    }

    public async ValueTask<bool> ExistsAsync(Recipe entity, CancellationToken cancellationToken = default)
    {
        var redisKey = GetRedisKey(entity.Id.ToString());
        var response = _cacheService.GetAsync<Recipe>(redisKey);

        if (response is not null)
        {
            _logger.LogInformation("Cache was hit for {redisKey} on {sourceName}",
                redisKey,
                nameof(CachedReadonlyRecipeRepository));

            return true;
        }

        return await _repo.ExistsAsync(entity, cancellationToken);
    }

    public async ValueTask<IEnumerable<Recipe>> GetManyAsync(CancellationToken cancellationToken = default)
    {
        var redisKey = GetRedisKey(nameof(GetManyAsync));
        var response = await _cacheService.GetAsync<IEnumerable<Recipe>>(redisKey);

        if (!response?.Any() ?? true)
        {
            _logger.LogInformation("Cache was not hit for {redisKey} on {sourceName}",
                redisKey,
                nameof(CachedReadonlyRecipeRepository));

            response = await _repo.GetManyAsync(cancellationToken);
            await _cacheService.SetAsync(redisKey, response, TimeSpan.FromSeconds(_cacheOptions.Value.SecondsDuration));
        }
        else
        {
            _logger.LogInformation("Cache was hit for {redisKey} on {sourceName}",
                redisKey,
                nameof(CachedReadonlyRecipeRepository));
        }

        return response;
    }

    public async ValueTask<Recipe> GetUniqueAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var redisKey = GetRedisKey(id.ToString());
        var Recipe = await _cacheService.GetAsync<Recipe>(redisKey);

        if (Recipe is null)
        {
            _logger.LogInformation("Cache was not hit for {redisKey} on {sourceName}",
                redisKey,
                nameof(CachedReadonlyRecipeRepository));

            Recipe = await _repo.GetUniqueAsync(id, cancellationToken);
            await _cacheService.SetAsync(redisKey, Recipe, TimeSpan.FromSeconds(_cacheOptions.Value.SecondsDuration));
        }
        else
        {
            _logger.LogInformation("Cache was hit for {redisKey} on {sourceName}",
                redisKey,
                nameof(CachedReadonlyRecipeRepository));
        }

        return Recipe;
    }

    public async ValueTask<IEnumerable<Recipe>> GetManyByAsync(Expression<Func<Recipe, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await _repo.GetManyByAsync(predicate, cancellationToken);
    }

    public async ValueTask<EntityQueryResultPaginated<Recipe>> GetByPaginated(Expression<Func<Recipe, bool>> predicate, int page, int pageSize, CancellationToken cancellationToken = default)
    {
        var result = await _repo.GetByPaginated(predicate, page, pageSize, cancellationToken);

        int totalCount = await CountAsync(cancellationToken);
        var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

        result.TotalPages = totalPages;
        result.TotalCount = totalCount;

        return result;
    }

    public async ValueTask<int> CountByAsync(Expression<Func<Recipe, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await _repo.CountByAsync(predicate, cancellationToken);
    }

    public async ValueTask<Recipe> GetUniqueByAsync(Expression<Func<Recipe, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await _repo.GetUniqueByAsync(predicate, cancellationToken);
    }
}
