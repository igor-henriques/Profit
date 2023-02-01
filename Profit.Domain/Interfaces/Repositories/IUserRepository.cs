namespace Profit.Infrastructure.Repository.Repositories;

public interface IUserRepository
{
    ValueTask Add(User user, CancellationToken cancellationToken = default);
    ValueTask<bool> Exists(User user, CancellationToken cancellationToken = default);
    ValueTask<User> GetUniqueAsync(Guid id, CancellationToken cancellationToken = default);
}