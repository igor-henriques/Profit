namespace Profit.Infrastructure.Repository.Repositories;

internal sealed class RecipeRepository : BaseRepository<Recipe, ProfitDbContext>, IRecipeRepository
{
    private readonly ProfitDbContext _context;
    private readonly ILogger<UnitOfWork> _logger;

    public RecipeRepository(ProfitDbContext context, ILogger<UnitOfWork> logger) : base(context, logger)
    {
        this._context = context;
        this._logger = logger;
    }

    public async Task<IEnumerable<Recipe>> GetRecipesAndRelationsByIngredientId(
        Guid ingredientId,
        CancellationToken cancellationToken = default)
    {
        var response = await _context.Recipes
            .Include(x => x.IngredientRecipeRelations)
            .ThenInclude(x => x.Ingredient)
            .ToListAsync(cancellationToken);

        _logger.LogInformation("{methodName} from {sourceName} retrieved {response}",
            nameof(GetRecipesAndRelationsByIngredientId),
            nameof(ProductRepository),
            response);

        return response;
    }
}
