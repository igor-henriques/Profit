namespace Profit.Domain.Commands.Product.CreateMany;

public sealed record CreateManyProductsCommand : BaseCommand, IRequest<IEnumerable<Guid>>
{
    public IEnumerable<CreateProductDTO> Products { get; init; }
}
