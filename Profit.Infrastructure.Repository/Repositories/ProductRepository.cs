namespace Profit.Infrastructure.Repository.Repositories;

internal sealed class ProductRepository : BaseRepository<Product, ProfitDbContext>, IProductRepository
{
    private readonly ProfitDbContext _context;
    private readonly ILogger<UnitOfWork> _logger;

    public ProductRepository(
        ProfitDbContext context,
        ILogger<UnitOfWork> logger) : base(context, logger)
    {
        this._context = context;
        this._logger = logger;
    }

    public async Task<IEnumerable<Product>> GetProductsByRecipeId(Guid recipeId, CancellationToken cancellationToken = default)
    {
        var response = await _context.Products
            .Include(x => x.Recipe)
            .Where(x => x.RecipeId == recipeId)
            .ToListAsync(cancellationToken);

        _logger.LogInformation("{methodName} from {sourceName} retrieved {response}",
            nameof(GetProductsByRecipeId),
            nameof(ProductRepository),
            response);

        return response;
    }
}
