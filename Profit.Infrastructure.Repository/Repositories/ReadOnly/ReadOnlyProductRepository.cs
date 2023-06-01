namespace Profit.Infrastructure.Repository.Repositories.ReadOnly;

public sealed class ReadOnlyProductRepository : ReadOnlyBaseRepository<Product, ProfitDbContext>, IReadOnlyProductRepository
{
    private readonly ProfitDbContext _context;
    private readonly ILogger<ReadOnlyProductRepository> _logger;

    public ReadOnlyProductRepository(
        ProfitDbContext context,
        ILogger<ReadOnlyProductRepository> localLogger,
        ILogger<ReadOnlyBaseRepository<Product, ProfitDbContext>> logger) : base(context, logger)
    {
        this._context = context;
        this._logger = localLogger;
    }

    public override async ValueTask<IEnumerable<Product>> GetManyAsync(CancellationToken cancellationToken = default)
    {
        var response = await _context.Products
            .AsNoTracking()
            .Include(x => x.Recipe)
            .ThenInclude(x => x.IngredientRecipeRelations)
            .ThenInclude(x => x.Ingredient)
            .ToListAsync(cancellationToken);

        _logger.LogInformation("{methodName} from {sourceName} retrieved {response}",
            nameof(GetManyAsync),
            nameof(ReadOnlyProductRepository),
            response);

        return response;
    }

    public override async ValueTask<IEnumerable<Product>> GetManyByAsync(Expression<Func<Product, bool>> predicate, CancellationToken cancellationToken = default)
    {
        var response = await _context.Products
            .AsNoTracking()
            .Include(x => x.Recipe)
            .ThenInclude(x => x.IngredientRecipeRelations)
            .ThenInclude(x => x.Ingredient)
            .Where(predicate)
            .ToListAsync(cancellationToken);

        _logger.LogInformation("{methodName} from {sourceName} retrieved {response}",
            nameof(GetManyByAsync),
            nameof(ReadOnlyProductRepository),
            response);

        return response;
    }

    public override async ValueTask<Product> GetUniqueAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var response = await _context.Products
            .AsNoTracking()
            .Include(x => x.Recipe)
            .ThenInclude(x => x.IngredientRecipeRelations)
            .ThenInclude(x => x.Ingredient)
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync(cancellationToken);

        _logger.LogInformation("{methodName} from {sourceName} retrieved {response}",
            nameof(GetUniqueAsync),
            nameof(ReadOnlyProductRepository),
            response);

        return response;
    }

    public override async ValueTask<Product> GetUniqueByAsync(Expression<Func<Product, bool>> predicate, CancellationToken cancellationToken = default)
    {
        var response = await _context.Products
            .AsNoTracking()
            .Include(x => x.Recipe)
            .ThenInclude(x => x.IngredientRecipeRelations)
            .ThenInclude(x => x.Ingredient)
            .Where(predicate)
            .FirstOrDefaultAsync(cancellationToken);

        _logger.LogInformation("{methodName} from {sourceName} retrieved {response}",
            nameof(GetUniqueByAsync),
            nameof(ReadOnlyProductRepository),
            response);

        return response;
    }

    public async Task<decimal> GetProductCost(Guid productId, CancellationToken cancellationToken = default)
    {
        var response = await _context.Products
            .AsNoTracking()
            .Include(x => x.Recipe)
            .ThenInclude(x => x.IngredientRecipeRelations)
            .Where(x => x.Id == productId)
            .SumAsync(x => x.Recipe.IngredientRecipeRelations.Select(y => y.RelationCost).Sum(), cancellationToken);

        _logger.LogInformation("{methodName} from {sourceName} retrieved {response}",
            nameof(GetProductCost),
            nameof(ReadOnlyProductRepository),
            response);

        return response;
    }
}
