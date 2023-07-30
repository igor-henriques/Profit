namespace Profit.Domain.Queries.Product.GetPaginated;

public sealed record GetPaginatedProductsQuery : BasePaginatedQuery, IQuery<EntityQueryResultPaginated<ProductDto>>
{
    public GetPaginatedProductsQuery(int pageNumber, int itemsPerPage) : base(pageNumber, itemsPerPage)
    {
    }
}