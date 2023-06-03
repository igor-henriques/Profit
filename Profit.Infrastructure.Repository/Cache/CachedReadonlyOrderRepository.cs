namespace Profit.Infrastructure.Repository.Cache;

public sealed class CachedReadonlyOrderRepository : ReadOnlyBaseRepository<Order, ProfitDbContext>, IReadOnlyOrderRepository
{
    public CachedReadonlyOrderRepository(
        ProfitDbContext context, 
        ILogger<ReadOnlyBaseRepository<Order, ProfitDbContext>> logger) : base(context, logger)
    {
    }
}
