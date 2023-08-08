namespace Profit.Domain.DTOs;

public readonly record struct IngredientDto
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public decimal Price { get; init; }
    public decimal Quantity { get; init; }
    public EMeasurementUnit MeasurementUnit { get; init; }
    public string ImageThumbnailUrl { get; init; }
    public string Description { get; init; }

    public IngredientDto(Guid id,
                         string name,
                         decimal price,
                         decimal quantity,
                         string imageThumbnailUrl,
                         EMeasurementUnit measurementUnit,
                         string description)
    {
        Id = id;
        Name = name;
        Price = price;
        Quantity = quantity;
        ImageThumbnailUrl = imageThumbnailUrl;
        MeasurementUnit = measurementUnit;
        Description = description;
    }

    public IngredientDto() { }
}
