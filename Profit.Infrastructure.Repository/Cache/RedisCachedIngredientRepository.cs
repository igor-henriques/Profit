namespace Profit.Infrastructure.Repository.Cache;

internal sealed class RedisCachedIngredientRepository : IIngredientRepository
{
    private readonly IRedisCacheService _cacheService;
    private readonly IngredientRepository _ingredientRepository;

    public RedisCachedIngredientRepository(
        ProfitDbContext context,
        ILogger<UnitOfWork> logger,
        IRedisCacheService cacheService)
    {
        this._ingredientRepository = new IngredientRepository(context, logger);
        this._cacheService = cacheService;
    }

    public async ValueTask Add(Ingredient entity, CancellationToken cancellationToken = default)
    {
        await _cacheService.SetAsync(entity.Id.ToString(), entity, TimeSpan.FromHours(1)); 
        await _ingredientRepository.Add(entity, cancellationToken);
    }

    public async Task BulkAdd(IEnumerable<Ingredient> ingredients)
    {
        foreach (var ingredient in ingredients)
        {
            await _cacheService.SetAsync(ingredient.Id.ToString(), ingredient, TimeSpan.FromHours(1));
        }

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
        var existsOnCache = _cacheService.Exists(entity.Id.ToString());

        if (!existsOnCache)
        {
            return await _ingredientRepository.Exists(entity, cancellationToken);
        }            

        return existsOnCache;
    }

    public ValueTask<IEnumerable<Ingredient>> GetManyAsync(CancellationToken cancellationToken = default)
    {
        return _ingredientRepository.GetManyAsync(cancellationToken);
    }

    public async ValueTask<Ingredient> GetUniqueAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var ingredient = await _cacheService.GetAsync<Ingredient>(id.ToString());

        if (ingredient is null)
        {
            ingredient = await _ingredientRepository.GetUniqueAsync(id, cancellationToken);
            await _cacheService.SetAsync(id.ToString(), ingredient, TimeSpan.FromHours(1));
        }

        return ingredient;
    }

    public async ValueTask Update(Ingredient entity)
    {
        var ingredient = await _cacheService.GetAsync<Ingredient>(entity.Id.ToString());

        if (ingredient is not null)
        {
            await _cacheService.SetAsync(ingredient.Id.ToString(), entity, TimeSpan.FromHours(1));
        }

        await _ingredientRepository.Update(entity);
    }
}
