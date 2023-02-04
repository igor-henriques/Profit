namespace Profit.Domain.Queries.Product.GetMany;

public readonly record struct GetManyProductsQuery : IRequest<IEnumerable<CreateProductDTO>>
{
}