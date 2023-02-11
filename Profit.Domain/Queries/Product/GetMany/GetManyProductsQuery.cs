namespace Profit.Domain.Queries.Product.GetMany;

public readonly record struct GetManyProductsQuery : IQuery<IEnumerable<ProductDTO>>
{
}