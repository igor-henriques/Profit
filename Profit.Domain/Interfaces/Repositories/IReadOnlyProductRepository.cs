namespace Profit.Infrastructure.Repository.Repositories.ReadOnly;

public interface IReadOnlyProductRepository : IReadOnlyBaseRepository<Product>
{
    Task<decimal> GetProductCost(Guid productId, CancellationToken cancellationToken = default);
}