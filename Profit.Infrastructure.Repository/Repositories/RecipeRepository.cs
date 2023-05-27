namespace Profit.Infrastructure.Repository.Repositories;

internal sealed class RecipeRepository : BaseRepository<Recipe, ProfitDbContext>, IRecipeRepository
{
    private readonly ProfitDbContext _context;
    private readonly ILogger<UnitOfWork> _logger;

    public RecipeRepository(
        ProfitDbContext context,
        ILogger<UnitOfWork> logger) : base(context, logger)
    {
        this._context = context;
        this._logger = logger;
    }

    public override async ValueTask Add(Recipe entity, CancellationToken cancellationToken = default)
    {
        var entityExists = await base.Exists(entity, cancellationToken);

        if (entityExists)
        {
            throw new InvalidOperationException($"{typeof(Recipe).Name} already exists");
        }

        _context.Recipes.Add(entity);

        foreach (var relation in entity.IngredientRecipeRelations)
        {
            relation.UpdateRecipeId(entity.Id);
        }

        _context.IngredientRecipeRelations.AddRange(entity.IngredientRecipeRelations);

        _logger.LogInformation("{entity} was added", entity);
    }

    public async Task<IEnumerable<Recipe>> GetRecipesAndRelationsByIngredientId(
        Guid ingredientId,
        CancellationToken cancellationToken = default)
    {
        var response = await _context.Recipes
            .Include(x => x.IngredientRecipeRelations)
            .Where(x => x.IngredientRecipeRelations.Any(y => y.IngredientId == ingredientId))
            .ToListAsync(cancellationToken);

        _logger.LogInformation("{response} records were retrieved", response.Count);

        return response;
    }

    public override async ValueTask<IEnumerable<Recipe>> GetManyAsync(CancellationToken cancellationToken = default)
    {
        var response = await _context.Recipes
            .Include(x => x.IngredientRecipeRelations)
            .ToListAsync(cancellationToken);

        _logger.LogInformation("{response} records were retrieved", response.Count);

        return response;
    }

    public override async ValueTask<Recipe> GetUniqueAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var response = await _context.Recipes
            .AsNoTracking()
            .Include(x => x.IngredientRecipeRelations)
            .FirstOrDefaultAsync(x => x.Id.Equals(id), cancellationToken);

        return response;
    }
}
