namespace Profit.Application.Queries.Order.GetUnique;

public readonly record struct GetUniqueOrderQuery : IQuery<OrderDto>
{
    public Guid Guid { get; }

    public GetUniqueOrderQuery(Guid guid)
    {
        Guid = guid;
    }
}
