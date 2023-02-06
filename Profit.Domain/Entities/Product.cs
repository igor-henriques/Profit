namespace Profit.Domain.Entities;

public sealed record Product : Entity<Product>
{
    public string Name { get; private set; }
    public decimal TotalPrice { get; private set; }
    public string ImageThumbnailUrl { get; private set; }
    public string Description { get; private set; }
    public Guid RecipeId { get; private set; }
    public Recipe Recipe { get; init; }

    public Product(
        string name,
        decimal totalPrice,
        string imageThumbnailUrl,
        string description,
        Guid recipeId,
        Recipe recipe)
    {
        Name = name;
        TotalPrice = totalPrice;
        ImageThumbnailUrl = imageThumbnailUrl;
        Description = description;
        RecipeId = recipeId;
        Recipe = recipe;

        Validate();
    }

    public Product() { }

    public override void Validate()
    {
        ArgumentValidator.ThrowIfNullOrEmpty(Name, nameof(Name));
        ArgumentValidator.ThrowIfNegative(TotalPrice, nameof(TotalPrice));
        ArgumentValidator.ThrowIfNullOrDefault(RecipeId, nameof(RecipeId));
    }

    public Product UpdateName(string name)
    {
        ArgumentValidator.ThrowIfNullOrEmpty(name);

        if (Name != name)
        {
            this.Name = name;
        }

        return this;
    }

    public Product UpdateImageThumbnailUrl(string imageThumbnailUrl)
    {
        ArgumentValidator.ThrowIfNullOrEmpty(imageThumbnailUrl);

        if (ImageThumbnailUrl != imageThumbnailUrl)
        {
            this.ImageThumbnailUrl = imageThumbnailUrl;
        }

        return this;
    }

    public Product UpdateRecipeId(Guid recipeId)
    {
        ArgumentValidator.ThrowIfNullOrDefault(recipeId);

        if (RecipeId != recipeId)
        {
            this.RecipeId = recipeId;
        }

        return this;
    }

    public Product UpdateDescription(string description)
    {
        if (Description != description)
        {
            this.Description = description;
        }

        return this;
    }

    public Product UpdateTotalPrice(decimal price)
    {
        ArgumentValidator.ThrowIfNegative(price);

        if (TotalPrice != price)
        {
            this.TotalPrice = price;
        }

        return this;
    }

    public override Product Update(Product entity)
    {
        UpdateName(entity.Name);
        UpdateTotalPrice(entity.TotalPrice);
        UpdateImageThumbnailUrl(entity.ImageThumbnailUrl);
        UpdateDescription(entity.ImageThumbnailUrl);
        UpdateRecipeId(entity.RecipeId);

        return this;
    }
}
