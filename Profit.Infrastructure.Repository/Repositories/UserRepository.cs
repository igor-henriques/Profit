namespace Profit.Infrastructure.Repository.Repositories;

internal sealed class UserRepository : IUserRepository
{
    private readonly ProfitDbContext _context;
    private readonly ILogger<UnitOfWork> _logger;

    public UserRepository(
        ProfitDbContext context,
        ILogger<UnitOfWork> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async ValueTask Add(User user, CancellationToken cancellationToken = default)
    {
        var entityExists = await this.Exists(user, cancellationToken);

        if (entityExists)
        {
            throw new InvalidOperationException("Entity already exists");
        }

        _context.Users.Add(user);
        _logger.LogInformation($"{user} was added");
    }

    public async ValueTask<bool> Exists(User user, CancellationToken cancellationToken = default)
    {
        if (user.Id.Equals(default))
            return false;

        var response = await _context.Users.AnyAsync(x => x.Id == user.Id, cancellationToken);
        _logger.LogInformation($"User with id {user.Id} exists: {response}");
        return response;
    }

    public async ValueTask<User> GetUniqueAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var response = await _context.Users.FindAsync(id, cancellationToken);
        _logger.LogInformation($"{response} was retrieved");
        return response;
    }
}
