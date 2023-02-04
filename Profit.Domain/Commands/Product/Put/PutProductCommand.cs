namespace Profit.Domain.Commands.Product.Put;

public sealed record PutProductCommand : BaseCommand, IRequest<Unit>
{
    public ProductDTO Product { get; init; }
}
