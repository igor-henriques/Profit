namespace Profit.Infrastructure.Repository.Repositories;

internal sealed class RecipeRepository : IRecipeRepository
{
    private readonly ProfitDbContext _context;
    private readonly ILogger<UnitOfWork> logger;

    public RecipeRepository(
        ProfitDbContext context,
        ILogger<UnitOfWork> logger)
    {
        this._context = context;
        this.logger = logger;
    }

    public async ValueTask Add(Recipe recipe, CancellationToken cancellationToken = default)
    {
        var entityExists = await this.Exists(recipe, cancellationToken);

        if (entityExists)
        {
            throw new InvalidOperationException("Entity already exists");
        }

        _context.Recipes.Add(recipe);
        logger.LogInformation($"{recipe} was added");
    }

    public void BulkAdd(IEnumerable<Recipe> recipes)
    {
        _context.Recipes.AddRange(recipes);
        logger.LogInformation($"{recipes.Count()} recipes were added");
    }

    public void Delete(Recipe recipe)
    {
        _context.Recipes.Remove(recipe);
        logger.LogInformation($"{recipe}");
    }

    public async ValueTask<Recipe> GetUniqueAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var response = await _context.Recipes.FindAsync(id, cancellationToken);
        logger.LogInformation($"{response} was retrieved");
        return response;
    }

    public async ValueTask<IEnumerable<Recipe>> GetManyAsync(CancellationToken cancellationToken = default)
    {
        var response = await _context.Recipes.ToListAsync(cancellationToken);
        logger.LogInformation($"{response.Count()} recipes were retrieved");
        return response;
    }

    public void Update(Recipe recipe)
    {
        _context.Recipes.Update(recipe);
        logger.LogInformation($"{recipe} was updated");
    }

    public async ValueTask<bool> Exists(Recipe recipe, CancellationToken cancellationToken = default)
    {
        var entityExists = await _context.Recipes.AnyAsync(
            p => p.Equals(recipe), cancellationToken);

        return entityExists;
    }

    public async ValueTask<int> CountAsync(CancellationToken cancellationToken = default)
    {
        var response = await _context.Recipes.CountAsync(cancellationToken);
        logger.LogInformation($"{response} recipes were counted");
        return response;
    }
}
