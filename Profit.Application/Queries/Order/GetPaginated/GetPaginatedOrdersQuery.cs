namespace Profit.Application.Queries.Order.GetPaginated;

public sealed record GetPaginatedOrdersQuery : BasePaginatedQuery, IQuery<EntityQueryResultPaginated<OrderDto>>
{
    public GetPaginatedOrdersQuery(int pageNumber, int itemsPerPage) : base(pageNumber, itemsPerPage)
    {
    }
}