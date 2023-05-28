namespace Profit.Infrastructure.Repository.Cache;

internal sealed class RedisCachedRecipeRepository : IRecipeRepository
{
    private readonly ITenantInfo _tenant;
    private readonly IRedisCacheService _cacheService;
    private readonly RecipeRepository _repo;
    private const string REDIS_PREFIX = "profit:recipe:";
    private readonly long _cacheExpirationInSeconds;
    private readonly ILogger<UnitOfWork> _logger;

    public RedisCachedRecipeRepository(
        ProfitDbContext context,
        ILogger<UnitOfWork> logger,
        IRedisCacheService cacheService,
        IConfiguration configuration,
        ITenantInfo tenant)
    {
        _repo = new RecipeRepository(context, logger);
        _cacheService = cacheService;
        _cacheExpirationInSeconds = configuration.GetValue<long>("CacheSecondsDuration");
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

    public async ValueTask Add(Recipe entity, CancellationToken cancellationToken = default)
    {
        await _repo.Add(entity, cancellationToken);
    }

    public void BulkAdd(IEnumerable<Recipe> ingredients)
    {
        _repo.BulkAdd(ingredients);
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
            count = await _repo.CountAsync(cancellationToken);
            await _cacheService.SetAsync(redisKey, count, TimeSpan.FromSeconds(_cacheExpirationInSeconds));
        }
        else
        {
            _logger.LogInformation("Cache was hit for {methodName} on {sourceName}",
                nameof(CountAsync),
                nameof(RedisCachedRecipeRepository));
        }

        return count;
    }

    public void Delete(Recipe entity)
    {
        _cacheService.Remove(entity.Id.ToString());
        _repo.Delete(entity);
    }

    public async ValueTask<bool> Exists(Recipe entity, CancellationToken cancellationToken = default)
    {
        var existsOnCache = _cacheService.Exists(entity.Id.ToString());

        if (!existsOnCache)
        {
            return await _repo.Exists(entity, cancellationToken);
        }
        else
        {
            _logger.LogInformation("Cache was hit for {methodName} on {sourceName}",
                nameof(Exists),
                nameof(RedisCachedRecipeRepository));
        }

        return existsOnCache;
    }

    public async ValueTask<IEnumerable<Recipe>> GetManyAsync(CancellationToken cancellationToken = default)
    {
        var response = await _cacheService.GetAllKeys<Recipe>(REDIS_PREFIX);

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
                nameof(RedisCachedRecipeRepository));
        }

        return response;
    }

    public async ValueTask<Recipe> GetUniqueAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var recipe = await _cacheService.GetAsync<Recipe>(GetRedisKey(id));

        if (recipe is null)
        {
            recipe = await _repo.GetUniqueAsync(id, cancellationToken);
            await _cacheService.SetAsync(GetRedisKey(id), recipe, TimeSpan.FromSeconds(_cacheExpirationInSeconds));
        }
        else
        {
            _logger.LogInformation("Cache was hit for {methodName} on {sourceName}",
                nameof(GetUniqueAsync),
                nameof(RedisCachedRecipeRepository));
        }

        return recipe;
    }

    public void Update(Recipe entity)
    {
        _repo.Update(entity);
    }

    public async Task<IEnumerable<Recipe>> GetRecipesAndRelationsByIngredientId(Guid ingredientId, CancellationToken cancellationToken = default)
    {
        var specificRedisKey = $"{nameof(GetRecipesAndRelationsByIngredientId)}{ingredientId}".ToLower();
        var recipes = await _cacheService.GetAsync<IEnumerable<Recipe>>(specificRedisKey);

        if (recipes is null)
        {
            recipes = await _repo.GetRecipesAndRelationsByIngredientId(ingredientId, cancellationToken);
            await _cacheService.SetAsync(specificRedisKey, recipes, TimeSpan.FromSeconds(_cacheExpirationInSeconds));
        }
        else
        {
            _logger.LogInformation("Cache was hit for {methodName} on {sourceName}",
                nameof(GetRecipesAndRelationsByIngredientId),
                nameof(RedisCachedRecipeRepository));
        }

        return recipes;
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
}
