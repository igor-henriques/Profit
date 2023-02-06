namespace Profit.Domain.Queries.User.GetMany;

public readonly record struct GetManyUsersQuery : IRequest<IEnumerable<UserDTO>>
{
}