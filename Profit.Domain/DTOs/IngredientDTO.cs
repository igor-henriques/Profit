namespace Profit.Domain.ValueObjects;

public readonly record struct IngredientDTO
{
    public string Name { get; init; }
    public decimal Price { get; init; }
    public decimal Quantity { get; init; }
    public decimal TotalPrice { get; init; }
    public string ImageThumbnailUrl { get; init; }

    public IngredientDTO(string name,
                                 decimal price,
                                 decimal quantity,
                                 decimal totalPrice,
                                 string imageThumbnailUrl)
    {
        Name = name;
        Price = price;
        Quantity = quantity;
        TotalPrice = totalPrice;
        ImageThumbnailUrl = imageThumbnailUrl;
    }
}
