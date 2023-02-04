namespace Profit.Domain.Queries.Product.GetUnique;

public readonly record struct GetUniqueProductQuery : IRequest<CreateProductDTO>
{
    public Guid Id { get; }

    public GetUniqueProductQuery(Guid id)
    {
        Id = id;
    }
}
