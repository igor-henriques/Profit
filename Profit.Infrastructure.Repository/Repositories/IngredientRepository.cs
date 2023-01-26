namespace Profit.Infrastructure.Repository.Repositories;

internal sealed class IngredientRepository : IIngredientRepository
{
    private readonly ProfitDbContext _context;
    private readonly ILogger<UnitOfWork> logger;

    public IngredientRepository(
        ProfitDbContext context,
        ILogger<UnitOfWork> logger)
    {
        this._context = context;
        this.logger = logger;
    }

    public void Add(Ingredient ingredient)
    {                
        _context.Ingredients.Add(ingredient);
        logger.LogInformation($"{ingredient} was added");
    }

    public void BulkAdd(IEnumerable<Ingredient> ingredients)
    {
        _context.Ingredients.AddRange(ingredients);
        logger.LogInformation($"{ingredients.Count()} ingredients were added");
    }

    public void Delete(Ingredient ingredient)
    {
        _context.Ingredients.Remove(ingredient);
        logger.LogInformation($"{ingredient} removed were added");
    }

    public async ValueTask<Ingredient> Get(Guid id, CancellationToken cancellationToken = default)
    {
        var response = await _context.Ingredients.FindAsync(id, cancellationToken);
        logger.LogInformation($"{response} was retrieved");
        return response;
    }

    public async ValueTask<IEnumerable<Ingredient>> GetMany(CancellationToken cancellationToken = default)
    {
        var response = await _context.Ingredients.ToListAsync(cancellationToken);
        logger.LogInformation($"{response.Count()} ingredients were retrieved");
        return response;
    }

    public void Update(Ingredient ingredient)
    {
        _context.Ingredients.Update(ingredient);
        logger.LogInformation($"{ingredient} was updated");
    }
}
