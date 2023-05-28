namespace Profit.Infrastructure.Repository.Repositories.ReadOnly;

public sealed class ReadOnlyUserRepository : ReadOnlyBaseRepository<User, AuthDbContext>, IReadOnlyUserRepository
{
    private readonly AuthDbContext _context;
    private readonly ILogger<ReadOnlyUserRepository> _logger;

    public ReadOnlyUserRepository(
        AuthDbContext context,
        ILogger<ReadOnlyUserRepository> localLogger,
        ILogger<ReadOnlyBaseRepository<User, AuthDbContext>> logger) : base(context, logger)
    {
        this._context = context;
        this._logger = localLogger;
    }

    public async Task<Guid> GetTenantIdByUsername(string username, CancellationToken cancellationToken = default)
    {
        ArgumentValidator.ThrowIfNullOrEmpty(username, nameof(username));

        var tenant = await _context.Users
           .AsNoTracking()
           .Where(x => x.Username.Equals(username))
           .Select(u => u.TenantId)
           .FirstOrDefaultAsync(cancellationToken);

        _logger.LogInformation("{methodName} from {sourceName} retrieved {response}",
            nameof(GetTenantIdByUsername),
            nameof(ReadOnlyUserRepository),
            tenant);

        return tenant;
    }

    public async Task<User> GetByUsername(string username, CancellationToken cancellationToken = default)
    {
        ArgumentValidator.ThrowIfNullOrEmpty(username, nameof(username));

        var user = await _context.Users
           .AsNoTracking()
           .Include(x => x.UserClaims)
           .FirstOrDefaultAsync(x => x.Username.Equals(username), cancellationToken);

        _logger.LogInformation("{methodName} from {sourceName} retrieved {response}",
            nameof(GetByUsername),
            nameof(ReadOnlyUserRepository),
            user);

        _ = user ?? throw new EntityNotFoundException(nameof(User));

        return user;
    }
}
