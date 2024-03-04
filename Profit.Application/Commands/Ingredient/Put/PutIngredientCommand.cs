namespace Profit.Application.Commands.Ingredient.Put;

public sealed record PutIngredientCommand : IRequest<Unit>
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public decimal Price { get; init; }
    public decimal Quantity { get; init; }
    public EMeasurementUnit MeasurementUnit { get; init; }
    public string ImageThumbnailUrl { get; init; }
    public string Description { get; init; }
    public bool IsDeleted { get; init; }

    public PutIngredientCommand(Guid id,
                         string name,
                         decimal price,
                         decimal quantity,
                         string imageThumbnailUrl,
                         EMeasurementUnit measurementUnit,
                         string description,
                         bool isDeleted)
    {
        Id = id;
        Name = name;
        Price = price;
        Quantity = quantity;
        ImageThumbnailUrl = imageThumbnailUrl;
        MeasurementUnit = measurementUnit;
        Description = description;
        IsDeleted = isDeleted;
    }
}
