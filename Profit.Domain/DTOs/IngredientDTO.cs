namespace Profit.Domain.DTOs;

public readonly record struct IngredientDto
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public decimal Price { get; init; }
    public decimal Quantity { get; init; }
    public EMeasurementUnit MeasurementUnitType { get; init; }
    public string ImageThumbnailUrl { get; init; }
    public string Description { get; init; }

    public IngredientDto(Guid id,
                         string name,
                         decimal price,
                         decimal quantity,
                         string imageThumbnailUrl,
                         EMeasurementUnit measurementUnitType,
                         string description)
    {
        Id = id;
        Name = name;
        Price = price;
        Quantity = quantity;
        ImageThumbnailUrl = imageThumbnailUrl;
        MeasurementUnitType = measurementUnitType;
        Description = description;
    }

    public IngredientDto() { }
}
