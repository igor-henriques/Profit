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
        _logger.LogInformation("{methodName} from {sourceName} is not implemented",
               nameof(BulkAdd),
               nameof(UserRepository));

        throw new NotImplementedException($"{nameof(BulkAdd)} is not implemented for {nameof(User)}");
    }


    public override void Delete(User entity)
    {
        var userClaims = _context.Claims.Where(x => x.UserId == entity.Id);

        if (userClaims.Any())
        {
            _context.Claims.RemoveRange(userClaims);

            _logger.LogInformation("{methodName} from {sourceName}: {entity} was marked to removal, but not commited: {values}",
               nameof(Delete),
               nameof(UserRepository),
               nameof(User),
               userClaims);
        }

        _context.Users.Remove(entity);

        _logger.LogInformation("{methodName} from {sourceName}: {entity} was marked to removal, but not commited: {value}",
               nameof(Delete),
               nameof(UserRepository),
               nameof(User),
               entity);
    }

    public override async ValueTask Add(User entity, CancellationToken cancellationToken = default)
    {
        var entityExists = await ExistsAsync(entity, cancellationToken);

        if (entityExists)
        {
            throw new InvalidOperationException($"User already exists");
        }

        _context.Users.Add(entity);
        _context.Claims.Add(new UserClaim()
        {
            ClaimType = "Username",
            ClaimValue = entity.Username,
            UserId = entity.Id
        });

        _logger.LogInformation("{methodName} from {sourceName}: {entity} was added, but not commited: {value}",
          nameof(Add),
          nameof(UserRepository),
          nameof(User),
          entity);
    }

    private async ValueTask<bool> ExistsAsync(User entity, CancellationToken cancellationToken = default)
    {
        var response = await _context.Users.AnyAsync(
            x => x.Username == entity.Username || x.Email == entity.Email, cancellationToken);

        _logger.LogInformation("{methodName} from {sourceName} retrieved {response}",
            nameof(ExistsAsync),
            nameof(UserRepository),
            response);

        return response;
    }
}
