namespace Profit.Domain.Interfaces.Repositories;

public interface IUserRepository
{
    public ValueTask Add(User entity, CancellationToken cancellationToken = default);
    public void Update(User entity);
    public ValueTask<User> GetUniqueAsync(Guid id, CancellationToken cancellationToken = default);
    public void Delete(User entity);
}
