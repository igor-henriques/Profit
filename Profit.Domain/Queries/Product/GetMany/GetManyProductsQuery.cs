namespace Profit.Domain.Queries.Product.GetPaginated;

public readonly record struct GetPaginatedProductsQuery : IQuery<IEnumerable<ProductDto>>
{
}