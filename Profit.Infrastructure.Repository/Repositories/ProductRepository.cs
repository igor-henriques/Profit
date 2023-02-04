namespace Profit.Infrastructure.Repository.Repositories;

internal sealed class ProductRepository : IProductRepository
{
    private readonly ProfitDbContext _context;
    private readonly ILogger<UnitOfWork> logger;

    public ProductRepository(
        ProfitDbContext context,
        ILogger<UnitOfWork> logger)
    {
        this._context = context;
        this.logger = logger;
    }

    public async ValueTask Add(Product product, CancellationToken cancellationToken = default)
    {
        var entityExists = await this.Exists(product, cancellationToken);

        if (entityExists)
        {
            throw new InvalidOperationException("Entity already exists");
        }

        _context.Products.Add(product);
        logger.LogInformation($"{product} was added");
    }

    public void BulkAdd(IEnumerable<Product> products)
    {
        _context.Products.AddRange(products);
        logger.LogInformation($"{products.Count()} products were added");
    }

    public void Delete(Product product)
    {
        _context.Products.Remove(product);
        logger.LogInformation($"{product}");
    }

    public async ValueTask<Product> GetUniqueAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var response = await _context.Products.FindAsync(id, cancellationToken);
        logger.LogInformation($"{response} was retrieved");
        return response;
    }

    public async ValueTask<IEnumerable<Product>> GetManyAsync(CancellationToken cancellationToken = default)
    {
        var response = await _context.Products.ToListAsync(cancellationToken);
        logger.LogInformation($"{response.Count()} products were retrieved");
        return response;
    }

    public void Update(Product product)
    {
        _context.Products.Update(product);
        logger.LogInformation($"{product} was updated");
    }

    public async ValueTask<bool> Exists(Product product, CancellationToken cancellationToken = default)
    {
        var entityExists = await _context.Products.AnyAsync(
            p => p.Equals(product), cancellationToken);

        return entityExists;
    }

    public async ValueTask<int> CountAsync(CancellationToken cancellationToken = default)
    {
        var response = await _context.Products.CountAsync(cancellationToken);
        logger.LogInformation($"{response} products were counted");
        return response;
    }
}
