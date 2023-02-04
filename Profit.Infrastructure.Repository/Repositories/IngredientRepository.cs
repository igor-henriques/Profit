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

    public async ValueTask Add(Ingredient ingredient, CancellationToken cancellationToken = default)
    {
        var entityExists = await this.Exists(ingredient, cancellationToken);

        if (entityExists)
        {
            throw new InvalidOperationException("Entity already exists");
        }

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
        logger.LogInformation($"{ingredient}");
    }

    public async ValueTask<Ingredient> GetUniqueAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var response = await _context.Ingredients.FindAsync(id, cancellationToken);
        logger.LogInformation($"{response} was retrieved");
        return response;
    }

    public async ValueTask<IEnumerable<Ingredient>> GetManyAsync(CancellationToken cancellationToken = default)
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

    public async ValueTask<bool> Exists(Ingredient ingredient, CancellationToken cancellationToken = default)
    {
        var entityExists = await _context.Ingredients.AnyAsync(
            i => i.Name.Equals(ingredient.Name) &&
                 i.MeasurementUnitType.Equals(ingredient.MeasurementUnitType) &&
                 i.Quantity.Equals(ingredient.Quantity) &&
                 i.Price.Equals(ingredient.Price) &&
                 i.ImageThumbnailUrl.Equals(ingredient.ImageThumbnailUrl), cancellationToken);

        return entityExists;
    }

    public async ValueTask<int> CountAsync(CancellationToken cancellationToken = default)
    {
        var response = await _context.Ingredients.CountAsync(cancellationToken);
        logger.LogInformation($"{response} ingredients were counted");
        return response;
    }
}
