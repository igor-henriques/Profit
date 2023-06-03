namespace Profit.Domain.Commands.Order.Create;

public sealed record CreateOrderCommand : IRequest<Guid>
{
    public Guid CustomerId { get; init; }
    public Guid AddressId { get; init; }
    public Guid InvoiceId { get; init; }
    public decimal TotalAmount { get; init; }
    public PaymentMethod PaymentMethod { get; init; }
    public OrderStatus OrderStatus { get; init; }
    public DateTime CreatedAt { get; init; }
    public DateTime? UpdatedAt { get; init; }
    public DateTime? PaidAt { get; init; }
    public DateTime? CanceledAt { get; init; }
    public ICollection<OrderDetailDto> OrderDetails { get; init; }
}