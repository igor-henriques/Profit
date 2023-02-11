namespace Profit.Domain.Queries.User.GetMany;

public readonly record struct GetManyUsersQuery : IQuery<IEnumerable<UserDTO>>
{
}