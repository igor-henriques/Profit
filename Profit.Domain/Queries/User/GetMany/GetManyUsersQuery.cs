namespace Profit.Domain.Queries.User.GetPaginated;

public readonly record struct GetPaginatedUsersQuery : IQuery<IEnumerable<UserDto>>
{
}