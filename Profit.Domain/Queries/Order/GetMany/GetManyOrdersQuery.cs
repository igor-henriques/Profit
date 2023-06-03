namespace Profit.Domain.Queries.Order.GetMany;

public readonly record struct GetManyOrdersQuery : IQuery<IEnumerable<OrderDto>>
{
}