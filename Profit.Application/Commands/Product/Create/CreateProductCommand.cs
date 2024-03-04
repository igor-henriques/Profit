namespace Profit.Application.Commands.Product.Create;

public sealed record CreateProductCommand : IRequest<Guid>
{
    public string Name { get; init; }
    public decimal TotalPrice { get; init; }
    public string ImageThumbnailUrl { get; init; }
    public string Description { get; init; }
    public Guid RecipeId { get; init; }
}