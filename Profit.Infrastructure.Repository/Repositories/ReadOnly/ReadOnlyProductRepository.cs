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
