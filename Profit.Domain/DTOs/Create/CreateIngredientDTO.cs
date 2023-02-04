namespace Profit.Domain.DTOs.Create;

public readonly record struct CreateIngredientDTO
{
    public string Name { get; init; }
    public decimal Price { get; init; }
    public decimal Quantity { get; init; }
    public EMeasurementUnit MeasurementUnitType { get; init; }
    public string ImageThumbnailUrl { get; init; }

    public CreateIngredientDTO(string name,
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

    public CreateIngredientDTO() { }
}
