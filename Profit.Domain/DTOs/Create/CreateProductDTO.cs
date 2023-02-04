namespace Profit.Domain.DTOs.Create;

public readonly record struct CreateProductDTO
{
    public string Name { get; init; }
    public decimal TotalPrice { get; init; }
    public string ImageThumbnailUrl { get; init; }
    public string Description { get; init; }
    public Guid RecipeId { get; init; }
}
