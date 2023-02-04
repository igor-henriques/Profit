namespace Profit.Domain.Commands.Product.Delete;

public sealed record DeleteProductCommand : BaseCommand, IRequest<Unit>
{
    public Guid ProductId { get; init; }
}
