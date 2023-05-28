namespace Profit.Domain.Commands.Ingredient.Create;

public sealed record CreateIngredientCommand : IRequest<Guid>
{
    public string Name { get; init; }
    public decimal Price { get; init; }
    public decimal Quantity { get; init; }
    public EMeasurementUnit MeasurementUnit { get; init; }
    public string ImageThumbnailUrl { get; init; }
    public string Description { get; init; }

    public CreateIngredientCommand(string name,
                         decimal price,
                         decimal quantity,
                         string imageThumbnailUrl,
                         EMeasurementUnit measurementUnit,
                         string description)
    {
        Name = name;
        Price = price;
        Quantity = quantity;
        ImageThumbnailUrl = imageThumbnailUrl;
        MeasurementUnit = measurementUnit;
        Description = description;
    }
}