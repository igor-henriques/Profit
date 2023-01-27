namespace Profit.Domain.ValueObjects;

public readonly record struct IngredientDTO
{
    public Guid Guid { get; init; }
    public string Name { get; init; }
    public decimal Price { get; init; }
    public decimal Quantity { get; init; }
    public string ImageThumbnailUrl { get; init; }

    public IngredientDTO(Guid guid,
                         string name,
                         decimal price,
                         decimal quantity,
                         string imageThumbnailUrl)
    {
        Guid = guid;
        Name = name;
        Price = price;
        Quantity = quantity;
        ImageThumbnailUrl = imageThumbnailUrl;
    }
}
