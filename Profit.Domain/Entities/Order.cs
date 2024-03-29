﻿namespace Profit.Domain.Entities;

public sealed record Order : Entity<Order>, IEntity
{
    public decimal TotalAmount { get; init; }
    public PaymentMethod PaymentMethod { get; init; }
    public OrderStatus OrderStatus { get; private set; }
    public DateTime CreatedAt { get; init; }
    public DateTime? PaidAt { get; private set; }
    public DateTime? CanceledAt { get; init; }
    public Guid? CustomerId { get; init; }
    public Customer Customer { get; init; }
    public Guid? AddressId { get; init; }
    public Address Address { get; init; }
    public ICollection<OrderDetail> OrderDetails { get; init; }
    public Guid? InvoiceId { get; init; }
    public Invoice Invoice { get; init; }

    public void Pay()
    {
        OrderStatus |= OrderStatus.Paid;
        UpdatedAt = DateTime.Now;
        PaidAt = DateTime.Now;
    }

    public void Unpay()
    {
        OrderStatus &= ~OrderStatus.Paid;
        UpdatedAt = DateTime.Now;
    }

    public override Order Update(Order entity)
    {
        throw new NotImplementedException();
    }

    public override void Validate()
    {
        throw new NotImplementedException();
    }
}
