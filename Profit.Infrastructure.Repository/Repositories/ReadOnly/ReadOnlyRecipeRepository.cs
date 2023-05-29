namespace Profit.Infrastructure.Repository.Repositories.ReadOnly;

public sealed class ReadOnlyRecipeRepository : ReadOnlyBaseRepository<Recipe, ProfitDbContext>,
    IReadOnlyRecipeRepository
{
    private readonly ProfitDbContext _context;
    private readonly ILogger<ReadOnlyRecipeRepository> _logger;

    public ReadOnlyRecipeRepository(
        ProfitDbContext context,
        ILogger<ReadOnlyRecipeRepository> localLogger,
        ILogger<ReadOnlyBaseRepository<Recipe, ProfitDbContext>> logger) : base(context, logger)
    {
        this._context = context;
        this._logger = localLogger;
    }

    public override async ValueTask<IEnumerable<Recipe>> GetManyAsync(CancellationToken cancellationToken = default)
    {
        var response = await _context.Recipes
            .AsNoTracking()
            .Include(r => r.IngredientRecipeRelations)
            .ToListAsync(cancellationToken);

        _logger.LogInformation("{methodName} from {sourceName} retrieved {response}",
            nameof(GetManyAsync),
            nameof(ReadOnlyRecipeRepository),
            response);

        return response;
    }

    public override async ValueTask<IEnumerable<Recipe>> GetManyByAsync(Expression<Func<Recipe, bool>> predicate, CancellationToken cancellationToken = default)
    {
        var response = await _context.Recipes
            .AsNoTracking()
            .Include(r => r.IngredientRecipeRelations)
            .Where(predicate)
            .ToListAsync(cancellationToken);

        _logger.LogInformation("{methodName} from {sourceName} retrieved {response}",
            nameof(GetManyByAsync),
            nameof(ReadOnlyRecipeRepository),
            response);

        return response;
    }

    public override async ValueTask<Recipe> GetUniqueAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var response = await _context.Recipes
            .AsNoTracking()
            .Include(r => r.IngredientRecipeRelations)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        _logger.LogInformation("{methodName} from {sourceName} retrieved {response}",
            nameof(GetUniqueAsync),
            nameof(ReadOnlyRecipeRepository),
            response);

        return response;
    }

    public override async ValueTask<Recipe> GetUniqueByAsync(Expression<Func<Recipe, bool>> predicate, CancellationToken cancellationToken = default)
    {
        var response = await _context.Recipes
              .AsNoTracking()
              .Include(r => r.IngredientRecipeRelations)
              .Where(predicate)
              .FirstOrDefaultAsync(cancellationToken);

        _logger.LogInformation("{methodName} from {sourceName} retrieved {response}",
            nameof(GetUniqueByAsync),
            nameof(ReadOnlyRecipeRepository),
            response);

        return response;
    }
}
