namespace Profit.Infrastructure.Repository.Cache;

internal sealed class RedisCachedRecipeRepository : IRecipeRepository
{
    private readonly IRedisCacheService _cacheService;
    private readonly RecipeRepository _recipeRepository;

    public RedisCachedRecipeRepository(
        ProfitDbContext context,
        ILogger<UnitOfWork> logger,
        IRedisCacheService cacheService)
    {
        this._recipeRepository= new RecipeRepository(context, logger);
        this._cacheService = cacheService;
    }
    public async ValueTask Add(Recipe entity, CancellationToken cancellationToken = default)
    {
        await _cacheService.SetAsync(entity.Id.ToString(), entity, TimeSpan.FromHours(1));
        await _recipeRepository.Add(entity, cancellationToken);
    }

    public async Task BulkAdd(IEnumerable<Recipe> ingredients)
    {
        foreach (var ingredient in ingredients)
        {
            await _cacheService.SetAsync(ingredient.Id.ToString(), ingredient, TimeSpan.FromHours(1));
        }

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

    public ValueTask<IEnumerable<Recipe>> GetManyAsync(CancellationToken cancellationToken = default)
    {
        return _recipeRepository.GetManyAsync(cancellationToken);
    }

    public async ValueTask<Recipe> GetUniqueAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var recipe = await _cacheService.GetAsync<Recipe>(id.ToString());

        if (recipe is null)
        {
            recipe = await _recipeRepository.GetUniqueAsync(id, cancellationToken);
            await _cacheService.SetAsync(id.ToString(), recipe, TimeSpan.FromHours(1));
        }

        return recipe;
    }

    public async ValueTask Update(Recipe entity)
    {
        var recipe = await _cacheService.GetAsync<Recipe>(entity.Id.ToString());

        if (recipe is not null)
        {
            await _cacheService.SetAsync(recipe.Id.ToString(), entity, TimeSpan.FromHours(1));
        }

        await _recipeRepository.Update(entity);
    }
}
