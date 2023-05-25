using Profit.Domain.Entities.Base;

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

    public async Task<IEnumerable<IngredientRecipeRelation>> GetIngredientRecipeRelationByIngredientId(
        Guid ingredientId,
        CancellationToken cancellationToken = default)
    {
        var response = await _context.IngredientRecipeRelations
            .Include(x => x.Recipe)
            .Include(x => x.Ingredient)
            .Where(x => x.IngredientId == ingredientId)
            .ToListAsync(cancellationToken);

        _logger.LogInformation("{response} records were retrieved", response.Count);

        return response;
    }

    public override async ValueTask<IEnumerable<Recipe>> GetManyAsync(CancellationToken cancellationToken = default)
    {
        var response = await _context.Recipes
            .Include(x => x.IngredientRecipeRelations)
            .ThenInclude(x => x.Ingredient)
            .ToListAsync(cancellationToken);

        _logger.LogInformation("{response} records were retrieved", response.Count);

        return response;
    }
}
