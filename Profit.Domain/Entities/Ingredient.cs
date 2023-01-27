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

        Validate();
    }

    public void Validate()
    {
        ArgumentValidator.ThrowIfNullOrEmpty(Name);
        ArgumentValidator.ThrowIfNegative(Price);
        ArgumentValidator.ThrowIfNegative(Quantity);
        ArgumentValidator.ThrowIfNullOrEmpty(ImageThumbnailUrl);
    }

    /// <summary>
    /// Updates all properties by the provided Ingredient instance.
    /// Runs validation on each property.
    /// Only updates properties that are different from current.
    /// </summary>
    /// <param name="ingredient"></param>
    /// <returns></returns>
    public Ingredient Update(Ingredient ingredient)
    {
        UpdateName(ingredient.Name);
        UpdatePrice(ingredient.Price);
        UpdateQuantity(ingredient.Quantity);
        UpdateImageThumbnailUrl(ingredient.ImageThumbnailUrl);

        return this;
    }

    public Ingredient UpdateName(string name)
    {
        ArgumentValidator.ThrowIfNullOrEmpty(name);

        if (Name != name)
        {
            this.Name = name;
        }

        return this;
    }

    public Ingredient UpdatePrice(decimal price)
    {
        ArgumentValidator.ThrowIfNegative(price);

        if (Price != price)
        {
            this.Price = price;
        }

        return this;
    }

    public Ingredient UpdateQuantity(decimal quantity)
    {
        ArgumentValidator.ThrowIfNegative(quantity);

        if (Quantity != quantity)
        {
            this.Quantity = quantity;
        }

        return this;
    }

    public Ingredient UpdateImageThumbnailUrl(string imageThumbnailUrl)
    {
        ArgumentValidator.ThrowIfNullOrEmpty(imageThumbnailUrl);

        if (ImageThumbnailUrl != imageThumbnailUrl)
        {
            this.ImageThumbnailUrl = imageThumbnailUrl;
        }

        return this;
    }
}