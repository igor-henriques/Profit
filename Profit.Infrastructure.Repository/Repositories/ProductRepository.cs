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

        _logger.LogInformation("{products} retrieved", response.Count);

        return response;
    }

    public async Task<decimal> GetProductCost(Guid productId, CancellationToken cancellationToken = default)
    {
        return await _context.Products
            .AsNoTracking()
            .Include(x => x.Recipe)
            .ThenInclude(x => x.IngredientRecipeRelations)
            .Where(x => x.Id == productId)
            .SumAsync(x => x.Recipe.IngredientRecipeRelations.Select(y => y.RelationCost).Sum(), cancellationToken);
    }
}
