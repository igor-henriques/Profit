﻿using Profit.Domain.Entities.Base;

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

    public override async ValueTask<bool> Exists(User entity, CancellationToken cancellationToken = default)
    {
        return await _context.Users.AnyAsync(
            x => x.Username == entity.Username | x.Email == entity.Email, cancellationToken);
    }

    public override async ValueTask Add(User entity, CancellationToken cancellationToken = default)
    {
        var entityExists = await Exists(entity, cancellationToken);

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
        _logger.LogInformation("{entity} was added", entity);
    }

    public async Task<User> GetByUsername(string username)
    {
        ArgumentValidator.ThrowIfNullOrEmpty(username, nameof(username));

        var user = await _context.Users
           .AsNoTracking()
           .Include(x => x.UserClaims)
           .FirstOrDefaultAsync(x => x.Username.Equals(username));

        _ = user ?? throw new EntityNotFoundException(nameof(User));

        return user;
    }
}
