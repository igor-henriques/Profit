namespace Profit.Domain.Entities;

public sealed record Product : Entity
{
    public string Name { get; private set; }
    public decimal TotalPrice { get; private set; }
    public string ImageThumbnailUrl { get; private set; }
    public string Description { get; private set; }
    public Guid RecipeId { get; init; }
    public Recipe Recipe { get; init; }

    public override void Validate()
    {
        throw new NotImplementedException();
    }

    public Product Update(Product entity)
    {
        Name = entity.Name;
        TotalPrice = entity.TotalPrice;
        ImageThumbnailUrl = entity.ImageThumbnailUrl;
        Description = entity.Description;

        return this;
    }
}
