namespace Profit.Infrastructure.Repository.Cache;

internal sealed class CachedRecipeRepository : IRecipeRepository
{
    private readonly ProfitDbContext _context;
    private readonly ILogger<UnitOfWork> logger;

    public CachedRecipeRepository(
        ProfitDbContext context,
        ILogger<UnitOfWork> logger)
    {        
        this._context = context;
        this.logger = logger;
    }

    public ValueTask Add(Recipe entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public void BulkAdd(IEnumerable<Recipe> ingredients)
    {
        throw new NotImplementedException();
    }

    public ValueTask<int> CountAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public void Delete(Recipe entity)
    {
        throw new NotImplementedException();
    }

    public ValueTask<bool> Exists(Recipe entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public ValueTask<IEnumerable<Recipe>> GetManyAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public ValueTask<Recipe> GetUniqueAsync(Guid id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public void Update(Recipe entity)
    {
        throw new NotImplementedException();
    }
}
