namespace Profit.Domain.Commands.Product.Patch;

public sealed record PatchProductCommand : BaseCommand, IRequest<Unit>
{
    public ProductDTO Product { get; init; }
}
