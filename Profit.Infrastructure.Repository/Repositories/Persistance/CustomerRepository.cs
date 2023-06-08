namespace Profit.Infrastructure.Repository.Repositories.Persistance;

internal sealed class CustomerRepository : BaseRepository<Customer, ProfitDbContext>, ICustomerRepository
{
    public CustomerRepository(ProfitDbContext context, ILogger<UnitOfWork> logger) : base(context, logger)
    {
    }
}
