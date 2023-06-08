namespace Profit.Infrastructure.Repository.Repositories.ReadOnly;

public sealed class ReadOnlyCustomerRepository : ReadOnlyBaseRepository<Customer, ProfitDbContext>, IReadOnlyCustomerRepository
{
    public ReadOnlyCustomerRepository(ProfitDbContext context,
                                      ILogger<ReadOnlyBaseRepository<Customer, ProfitDbContext>> logger) : base(context, logger)
    {
    }
}
