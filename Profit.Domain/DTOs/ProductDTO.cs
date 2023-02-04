namespace Profit.Domain.DTOs;

public readonly record struct ProductDTO
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public decimal TotalPrice { get; init; }
    public string ImageThumbnailUrl { get; init; }
    public string Description { get; init; }
    public Guid RecipeId { get; init; }
}
