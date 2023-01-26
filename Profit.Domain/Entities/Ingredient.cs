namespace Profit.Domain.Entities;

public sealed record Ingredient : Entity
{
    public string Name { get; private set; }
    public decimal Price { get; private set; }
    public decimal Quantity { get; private set; }
    public decimal UnitPrice { get => Quantity is 0 ? 0 : Price / Quantity; }
    public string ImageThumbnailUrl { get; private set; }

    public Ingredient(string name,
                      decimal price,
                      decimal quantity,
                      string imageThumbnailUrl)
    {
        Name = name;
        Price = price;
        Quantity = quantity;
        ImageThumbnailUrl = imageThumbnailUrl;
    }

    public Ingredient() { }

    public Ingredient Update(Ingredient ingredient)
    {
        ArgumentValidator.ThrowIfNullOrEmpty(ingredient.Name);
        ArgumentValidator.ThrowIfNegative(ingredient.Price);
        ArgumentValidator.ThrowIfNegative(ingredient.Quantity);
        ArgumentValidator.ThrowIfNullOrEmpty(ingredient.ImageThumbnailUrl);

        this.Name = ingredient.Name;
        this.Price = ingredient.Price;
        this.Quantity = ingredient.Quantity;
        this.ImageThumbnailUrl = ingredient.ImageThumbnailUrl;

        return this;
    }

    public Ingredient UpdateName(string name)
    {
        ArgumentValidator.ThrowIfNullOrEmpty(name);
        this.Name = name;
        return this;
    }

    public Ingredient UpdatePrice(decimal price)
    {
        ArgumentValidator.ThrowIfNegative(price);
        this.Price = price;
        return this;
    }

    public Ingredient UpdateQuantity(decimal quantity)
    {
        ArgumentValidator.ThrowIfNegative(quantity);
        this.Quantity = quantity;
        return this;
    }

    public Ingredient UpdateImageThumbnailUrl(string imageThumbnailUrl)
    {
        ArgumentValidator.ThrowIfNullOrEmpty(imageThumbnailUrl);
        this.ImageThumbnailUrl = imageThumbnailUrl;
        return this;
    }

    public static Ingredient Create(string name,
                                    decimal price,
                                    decimal quantity,
                                    string imageThumbnailUrl)
    {
        ArgumentValidator.ThrowIfNullOrEmpty(name);
        ArgumentValidator.ThrowIfNegative(price);
        ArgumentValidator.ThrowIfNegative(quantity);
        ArgumentValidator.ThrowIfNullOrEmpty(imageThumbnailUrl);

        return new Ingredient(name, price, quantity, imageThumbnailUrl);
    }
}