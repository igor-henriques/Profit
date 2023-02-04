namespace Profit.Domain.DTOs;

public readonly record struct IngredientDTO
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public decimal Price { get; init; }
    public decimal Quantity { get; init; }
    public EMeasurementUnit MeasurementUnitType { get; init; }
    public string ImageThumbnailUrl { get; init; }

    public IngredientDTO(string name,
                         decimal price,
                         decimal quantity,
                         string imageThumbnailUrl,
                         EMeasurementUnit measurementUnitType)
    {
        Name = name;
        Price = price;
        Quantity = quantity;
        ImageThumbnailUrl = imageThumbnailUrl;
        MeasurementUnitType = measurementUnitType;
    }

    public IngredientDTO() { }
}
