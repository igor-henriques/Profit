namespace Profit.Infrastructure.Repository.Repositories.ReadOnly;

public interface IReadOnlyUserRepository : IReadOnlyBaseRepository<User>
{
    Task<Guid> GetTenantIdByUsername(string username, CancellationToken cancellationToken = default);
    Task<User> GetByUsername(string username, CancellationToken cancellationToken = default);
}