namespace Profit.Domain.Commands.Product.CreateMany;

public sealed record CreateManyProductsCommand : IRequest<IEnumerable<Guid>>
{
    public IEnumerable<CreateProductCommand> Products { get; init; }
}
