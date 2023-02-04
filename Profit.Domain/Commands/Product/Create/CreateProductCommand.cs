namespace Profit.Domain.Commands.Product.Create;

public sealed record CreateProductCommand : BaseCommand, IRequest<Guid>
{
    public CreateProductDTO Product { get; init; }
}