namespace Profit.Infrastructure.Repository.Repositories;

public sealed class UserRepository : IUserRepository
{
    private readonly ProfitDbContext _context;
    private readonly ILogger<UnitOfWork> logger;

    public UserRepository(
        ProfitDbContext context,
        ILogger<UnitOfWork> logger)
    {
        this._context = context;
        this.logger = logger;
    }

    public async ValueTask Add(User user, CancellationToken cancellationToken = default)
    {
        var entityExists = await _context.Users.AnyAsync(u => u.Guid.Equals(user.Guid), cancellationToken);

        if (entityExists)
        {
            throw new InvalidOperationException("Entity already exists");
        }        

        _context.Claims.AddRange(user.Claims);
        _context.Users.Add(user);
        logger.LogInformation($"{user} was added");
    }

    public void Delete(User entity)
    {
        _context.Claims.RemoveRange(entity.Claims);
        _context.Users.Remove(entity);
        logger.LogInformation($"{entity} was deleted");
    }

    public async ValueTask<User> GetUniqueAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var response = await _context.Users
            .Include(x => x.Claims)
            .FirstOrDefaultAsync(x => x.Guid.Equals(id), cancellationToken);
        
        logger.LogInformation($"{response} was retrieved");
        return response;
    }

    public void Update(User entity)
    {
        _context.Claims.UpdateRange(entity.Claims);
        _context.Users.Update(entity);
        logger.LogInformation($"{entity} was updated");
    }
}
