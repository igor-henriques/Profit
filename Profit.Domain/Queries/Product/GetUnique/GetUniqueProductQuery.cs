namespace Profit.Domain.Queries.Product.GetUnique;

public readonly record struct GetUniqueProductQuery : IQuery<ProductDTO>
{
    public Guid Id { get; }

    public GetUniqueProductQuery(Guid id)
    {
        Id = id;
    }
}
