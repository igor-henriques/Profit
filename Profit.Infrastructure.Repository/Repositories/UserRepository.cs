namespace Profit.Infrastructure.Repository.Repositories;

internal sealed class UserRepository : BaseRepository<User>, IUserRepository
{
    private readonly ProfitDbContext _context;
    private readonly ILogger<UnitOfWork> _logger;

    public UserRepository(
        ProfitDbContext context,
        ILogger<UnitOfWork> logger) : base(context, logger)
    {
        _context = context;
        _logger = logger;
    }
}
