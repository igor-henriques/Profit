namespace Profit.Infrastructure.Repository.Repositories;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User> GetByUsername(string username);
    
}