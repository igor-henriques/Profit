namespace Profit.Application.Commands.Product.Delete;

public sealed record DeleteProductCommand : IRequest<Unit>
{
    public Guid ProductId { get; init; }
}
