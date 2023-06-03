namespace Profit.Infrastructure.Repository.Repositories.ReadOnly;

public sealed class ReadOnlyOrderRepository : ReadOnlyBaseRepository<Order, ProfitDbContext>,
    IReadOnlyOrderRepository
{
    public ReadOnlyOrderRepository(
        ProfitDbContext context,
        ILogger<ReadOnlyBaseRepository<Order, ProfitDbContext>> logger) : base(context, logger)
    {
    }
}