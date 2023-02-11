namespace Profit.Infrastructure.Repository.Repositories;

internal sealed class UserRepository : BaseRepository<User, AuthDbContext>, IUserRepository
{
    private readonly AuthDbContext _context;
    private readonly ILogger<UnitOfWork> _logger;

    public UserRepository(
        AuthDbContext context,
        ILogger<UnitOfWork> logger) : base(context, logger)
    {
        _context = context;
        _logger = logger;
    }

    public override void BulkAdd(IEnumerable<User> entities)
    {
        throw new NotImplementedException($"{nameof(BulkAdd)} is not implemented for {nameof(User)}");
    }
}
