namespace Profit.Domain.ValueObjects;

public readonly record struct IngredientDTO
{
    public string Name { get; init; }
    public decimal Price { get; init; }
    public decimal Quantity { get; init; }
    public string ImageThumbnailUrl { get; init; }

    public IngredientDTO(string name,
                         decimal price,
                         decimal quantity,
                         string imageThumbnailUrl)
    {
        Name = name;
        Price = price;
        Quantity = quantity;
        ImageThumbnailUrl = imageThumbnailUrl;
    }

    public IngredientDTO() { }
}
