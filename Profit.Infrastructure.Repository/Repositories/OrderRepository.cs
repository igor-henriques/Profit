namespace Profit.Infrastructure.Repository.Repositories;

internal sealed class OrderRepository : BaseRepository<Order, ProfitDbContext>, IOrderRepository
{
    public OrderRepository(ProfitDbContext context, ILogger<UnitOfWork> logger) : base(context, logger)
    {
    }
}
