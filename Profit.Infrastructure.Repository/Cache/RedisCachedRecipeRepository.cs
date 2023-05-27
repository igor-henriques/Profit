namespace Profit.Infrastructure.Repository.Cache;

internal sealed class RedisCachedRecipeRepository : IRecipeRepository
{
    private readonly IRedisCacheService _cacheService;
    private readonly RecipeRepository _recipeRepository;
    private const string REDIS_RECIPE_PREFIX = "profit:recipe:";
    private readonly long _cacheExpirationInSeconds;

    public RedisCachedRecipeRepository(
        ProfitDbContext context,
        ILogger<UnitOfWork> logger,
        IRedisCacheService cacheService,
        IConfiguration configuration)
    {
        this._recipeRepository = new RecipeRepository(context, logger);
        this._cacheService = cacheService;
        this._cacheExpirationInSeconds = configuration.GetValue<long>("CacheSecondsDuration");
    }
    private static string GetRedisKey(Guid id)
    {
        return $"{REDIS_RECIPE_PREFIX}{id}";
    }

    public async ValueTask Add(Recipe entity, CancellationToken cancellationToken = default)
    {
        await _recipeRepository.Add(entity, cancellationToken);
    }

    public void BulkAdd(IEnumerable<Recipe> ingredients)
    {
        _recipeRepository.BulkAdd(ingredients);
    }

    public async ValueTask<int> CountAsync(CancellationToken cancellationToken = default)
    {
        return await _recipeRepository.CountAsync(cancellationToken);
    }

    public void Delete(Recipe entity)
    {
        _cacheService.Remove(entity.Id.ToString());
        _recipeRepository.Delete(entity);
    }

    public async ValueTask<bool> Exists(Recipe entity, CancellationToken cancellationToken = default)
    {
        var existsOnCache = _cacheService.Exists(entity.Id.ToString());

        if (!existsOnCache)
        {
            return await _recipeRepository.Exists(entity, cancellationToken);
        }

        return existsOnCache;
    }

    public async ValueTask<IEnumerable<Recipe>> GetManyAsync(CancellationToken cancellationToken = default)
    {
        var response = await _cacheService.GetAllKeys<Recipe>(REDIS_RECIPE_PREFIX);

        if (!response.Any())
        {
            response = await _recipeRepository.GetManyAsync(cancellationToken);

            foreach (var item in response)
            {
                await _cacheService.SetAsync(GetRedisKey(item.Id), item, TimeSpan.FromSeconds(_cacheExpirationInSeconds));
            }
        }

        return response;
    }

    public async ValueTask<Recipe> GetUniqueAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var recipe = await _cacheService.GetAsync<Recipe>(GetRedisKey(id));

        if (recipe is null)
        {
            recipe = await _recipeRepository.GetUniqueAsync(id, cancellationToken);
            await _cacheService.SetAsync(GetRedisKey(id), recipe, TimeSpan.FromSeconds(_cacheExpirationInSeconds));
        }

        return recipe;
    }

    public void Update(Recipe entity)
    {
        _recipeRepository.Update(entity);
    }

    public async Task<IEnumerable<Recipe>> GetRecipesAndRelationsByIngredientId(Guid ingredientId, CancellationToken cancellationToken = default)
    {
        var specificRedisKey = $"{nameof(GetRecipesAndRelationsByIngredientId)}{ingredientId}".ToLower();
        var recipes = await _cacheService.GetAsync<IEnumerable<Recipe>>(specificRedisKey);

        if (recipes is null)
        {
            recipes = await _recipeRepository.GetRecipesAndRelationsByIngredientId(ingredientId, cancellationToken);
            await _cacheService.SetAsync(specificRedisKey, recipes, TimeSpan.FromSeconds(_cacheExpirationInSeconds));
        }

        return recipes;
    }
}
