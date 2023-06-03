namespace Profit.Domain.DTOs;

public readonly record struct OrderDetailDto
{
    public Guid Id { get; init; }
    public Guid OrderId { get; init; }    
    public Guid ProductId { get; init; }    
    public int Quantity { get; init; }
    public decimal Taxes { get; init; }
    public decimal Discount { get; init; }
    public decimal Total { get; init; }
}
