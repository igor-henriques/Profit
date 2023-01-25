namespace Profit.Domain.Entities;

public sealed record Ingredient : Entity
{    
    public string Name { get; private set; }        
    public decimal Price { get; private set; }
    public decimal Quantity { get; private set; }
    public decimal TotalPrice { get; private set; }
    public decimal UnitPrice { get => Price / Quantity; }
    public string ImageThumbnailUrl { get; private set; }

    public Ingredient(string name,
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

    public void UpdatePrice(decimal price)
    {
        IngredientValidator.ValidatePrice(price);
        
        Price = price;
    }
}