namespace Profit.Infrastructure.Repository.Cache;

internal sealed class CachedProductRepository : IProductRepository
{
    private readonly ProfitDbContext _context;
    private readonly ILogger<UnitOfWork> logger;

    public CachedProductRepository(
        ProfitDbContext context,
        ILogger<UnitOfWork> logger)
    {
        this._context = context;
        this.logger = logger;
    }

    public ValueTask Add(Product entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public void BulkAdd(IEnumerable<Product> ingredients)
    {
        throw new NotImplementedException();
    }

    public ValueTask<int> CountAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public void Delete(Product entity)
    {
        throw new NotImplementedException();
    }

    public ValueTask<bool> Exists(Product entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public ValueTask<IEnumerable<Product>> GetManyAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public ValueTask<Product> GetUniqueAsync(Guid id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public void Update(Product entity)
    {
        throw new NotImplementedException();
    }
}
