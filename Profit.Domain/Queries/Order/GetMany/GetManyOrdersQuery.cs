namespace Profit.Domain.Queries.Order.GetPaginated;

public readonly record struct GetPaginatedOrdersQuery : IQuery<IEnumerable<OrderDto>>
{
}