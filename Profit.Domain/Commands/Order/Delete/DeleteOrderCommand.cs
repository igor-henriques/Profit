namespace Profit.Domain.Commands.Order.Delete;

public sealed record DeleteOrderCommand : IRequest<Unit>
{
    public Guid OrderId { get; init; }
}
