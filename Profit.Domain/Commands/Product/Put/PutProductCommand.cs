namespace Profit.Domain.Commands.Product.Put;

public sealed record PutProductCommand : IRequest<Unit>
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public decimal TotalPrice { get; init; }
    public string ImageThumbnailUrl { get; init; }
    public string Description { get; init; }
    public Guid RecipeId { get; init; }
}
