namespace Profit.Domain.Queries.User.GetPaginated;

public sealed record GetPaginatedUsersQuery : BasePaginatedQuery, IQuery<EntityQueryResultPaginated<UserDto>>
{
    public GetPaginatedUsersQuery(int pageNumber, int itemsPerPage) : base(pageNumber, itemsPerPage)
    {
    }
}