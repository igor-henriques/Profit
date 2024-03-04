namespace Profit.Domain.Entities;

public sealed record Ingredient : Entity<Ingredient>, IEntity
{
    public string Name { get; private set; }
    public decimal Price { get; private set; }
    public EMeasurementUnit MeasurementUnit { get; private set; }
    public decimal Quantity { get; private set; }
    public decimal UnitPrice { get => Price is 0 ? 0 : Price / Quantity; }
    public string ImageThumbnailUrl { get; private set; }
    public string Description { get; private set; }
    public ICollection<IngredientRecipeRelation> IngredientRecipeRelations { get; init; }

    public Ingredient(string name,
                      decimal price,
                      EMeasurementUnit measurementUnit,
                      decimal quantity,
                      string imageThumbnailUrl)
    {
        Name = name;
        Price = price;
        MeasurementUnit = measurementUnit;
        Quantity = quantity;
        ImageThumbnailUrl = imageThumbnailUrl;

        Validate();
    }

    public Ingredient() { }

    public override void Validate()
    {
        ArgumentValidator.ThrowIfNullOrEmpty(Name, nameof(Name));
        ArgumentValidator.ThrowIfNegative(Price, nameof(Price));
        ArgumentValidator.ThrowIfZero(Quantity, nameof(Quantity));
    }

    /// <summary>
    /// Updates all properties by the provided Ingredient instance.
    /// Runs validation on each property.
    /// Only updates properties that are different from current.
    /// </summary>
    /// <param name="ingredient"></param>
    /// <returns></returns>
    public override Ingredient Update(Ingredient ingredient)
    {
        UpdateName(ingredient.Name);
        UpdatePrice(ingredient.Price);
        UpdateMeasurementUnit(ingredient.MeasurementUnit);
        UpdateQuantity(ingredient.Quantity);
        UpdateImageThumbnailUrl(ingredient.ImageThumbnailUrl);
        UpdateDescription(ingredient.Description);

        return this;
    }

    public Ingredient UpdateMeasurementUnit(EMeasurementUnit incomingMeasurementUnit)
    {
        if (MeasurementUnit != incomingMeasurementUnit)
        {
            MeasurementUnit.CheckForInvalidConversions(incomingMeasurementUnit);
            this.MeasurementUnit = incomingMeasurementUnit;
        }

        return this;
    }

    public Ingredient UpdateQuantity(decimal quantity)
    {
        ArgumentValidator.ThrowIfZero(quantity, nameof(quantity));
        ArgumentValidator.ThrowIfNegative(quantity, nameof(quantity));

        this.Quantity = quantity;
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

    public Ingredient UpdateDescription(string description)
    {
        if (Description != description)
        {
            this.Description = description;
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