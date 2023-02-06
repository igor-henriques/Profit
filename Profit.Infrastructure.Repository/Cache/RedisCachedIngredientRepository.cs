namespace Profit.Infrastructure.Repository.Cache;

internal sealed class RedisCachedIngredientRepository : IIngredientRepository
{
    private readonly IRedisCacheService _cacheService;
    private readonly IngredientRepository _ingredientRepository;
    private const string REDIS_INGREDIENT_PREFIX = "profit:ingredient:";
    private readonly long _cacheExpirationInSeconds;

    public RedisCachedIngredientRepository(
        ProfitDbContext context,
        ILogger<UnitOfWork> logger,
        IRedisCacheService cacheService,
        IConfiguration configuration)
    {
        this._ingredientRepository = new IngredientRepository(context, logger);
        this._cacheService = cacheService;
        this._cacheExpirationInSeconds = configuration.GetValue<long>("CacheSecondsDuration");
    }

    private static string GetRedisKey(Guid id)
    {
        return $"{REDIS_INGREDIENT_PREFIX}{id}";
    }

    public async ValueTask Add(Ingredient entity, CancellationToken cancellationToken = default)
    {
        await _ingredientRepository.Add(entity, cancellationToken);
    }

    public void BulkAdd(IEnumerable<Ingredient> ingredients)
    {
        _ingredientRepository.BulkAdd(ingredients);
    }

    public async ValueTask<int> CountAsync(CancellationToken cancellationToken = default)
    {
        return await _ingredientRepository.CountAsync(cancellationToken);
    }

    public void Delete(Ingredient entity)
    {
        _cacheService.Remove(entity.Id.ToString());
        _ingredientRepository.Delete(entity);
    }

    public async ValueTask<bool> Exists(Ingredient entity, CancellationToken cancellationToken = default)
    {
        return await _ingredientRepository.Exists(entity, cancellationToken); ;
    }

    public async ValueTask<IEnumerable<Ingredient>> GetManyAsync(CancellationToken cancellationToken = default)
    {
        var response = await _cacheService.GetAllKeys<Ingredient>(REDIS_INGREDIENT_PREFIX);

        if (!response.Any())
        {
            response = await _ingredientRepository.GetManyAsync(cancellationToken);

            foreach (var item in response)
            {
                await _cacheService.SetAsync(GetRedisKey(item.Id), item, TimeSpan.FromSeconds(_cacheExpirationInSeconds));
            }
        }

        return response;
    }

    public async ValueTask<Ingredient> GetUniqueAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var ingredient = await _cacheService.GetAsync<Ingredient>(GetRedisKey(id));

        if (ingredient is null)
        {
            ingredient = await _ingredientRepository.GetUniqueAsync(id, cancellationToken);
            await _cacheService.SetAsync(GetRedisKey(id), ingredient, TimeSpan.FromSeconds(_cacheExpirationInSeconds));
        }

        return ingredient;
    }

    public void Update(Ingredient entity)
    {
        _ingredientRepository.Update(entity);
    }
}
