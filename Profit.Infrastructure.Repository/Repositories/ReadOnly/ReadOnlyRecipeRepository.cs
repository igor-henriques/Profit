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

    public override async ValueTask<EntityQueryResultPaginated<Recipe>> GetPaginatedAsync(
        BasePaginatedQuery paginatedQuery,
        CancellationToken cancellationToken = default)
    {
        var response = await _context.Recipes
            .AsNoTracking()
            .Include(r => r.IngredientRecipeRelations)
            .ToListAsync(cancellationToken);

        _logger.LogInformation("{methodName} from {sourceName} retrieved {response}",
            nameof(GetPaginatedAsync),
            nameof(ReadOnlyRecipeRepository),
            response);

        return new EntityQueryResultPaginated<Recipe>()
        {
            Data = response,
            ItemsPerPage = paginatedQuery.ItemsPerPage,
            PageNumber = paginatedQuery.PageNumber
        };
    }

    public override async ValueTask<EntityQueryResultPaginated<Recipe>> GetByPaginatedAsync(Expression<Func<Recipe, bool>> predicate, BasePaginatedQuery paginatedQuery, CancellationToken cancellationToken = default)
    {
        var response = await _context.Recipes
            .AsNoTracking()
            .Include(r => r.IngredientRecipeRelations)
            .Where(predicate)
            .ToListAsync(cancellationToken);

        _logger.LogInformation("{methodName} from {sourceName} retrieved {response}",
            nameof(GetByPaginatedAsync),
            nameof(ReadOnlyRecipeRepository),
            response);

        return new EntityQueryResultPaginated<Recipe>()
        {
            Data = response,
            PageNumber = paginatedQuery.PageNumber,
            ItemsPerPage = paginatedQuery.ItemsPerPage
        };
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
