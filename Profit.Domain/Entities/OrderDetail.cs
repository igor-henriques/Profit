namespace Profit.Domain.Entities;

public sealed record OrderDetail : Entity<OrderDetail>
{
    public Guid OrderId { get; init; }
    public Order Order { get; init; }
    public Guid ProductId { get; init; }
    public Product Product { get; init; }
    public int Quantity { get; init; }
    public decimal Taxes { get; init; }
    public decimal Discount { get; init; }
    public decimal Total { get; init; }

    public override OrderDetail Update(OrderDetail entity)
    {
        throw new NotImplementedException();
    }

    public override void Validate()
    {
        throw new NotImplementedException();
    }
}
