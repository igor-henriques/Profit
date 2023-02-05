namespace Profit.Infrastructure.Repository.Cache;

internal sealed class CachedIngredientRepository : IIngredientRepository
{    
    private readonly IngredientRepository _ingredientRepository;
    
    public CachedIngredientRepository(
        ProfitDbContext context,
        ILogger<UnitOfWork> logger)
    {
        this._ingredientRepository = new IngredientRepository(context, logger);
    }

    public ValueTask Add(Ingredient entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public void BulkAdd(IEnumerable<Ingredient> ingredients)
    {
        throw new NotImplementedException();
    }

    public ValueTask<int> CountAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public void Delete(Ingredient entity)
    {
        throw new NotImplementedException();
    }

    public ValueTask<bool> Exists(Ingredient entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public ValueTask<IEnumerable<Ingredient>> GetManyAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public ValueTask<Ingredient> GetUniqueAsync(Guid id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public void Update(Ingredient entity)
    {
        throw new NotImplementedException();
    }
}
