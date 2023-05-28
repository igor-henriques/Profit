namespace Profit.Domain.DTOs;

public readonly record struct IngredientRecipeRelationDto
{
    public IngredientRecipeRelationDto(Guid ingredientId, EMeasurementUnit measurementUnit, decimal ingredientCount)
    {
        IngredientId = ingredientId;
        MeasurementUnit = measurementUnit;
        IngredientCount = ingredientCount;
    }
    public IngredientRecipeRelationDto() { }

    public Guid IngredientId { get; init; }
    public EMeasurementUnit MeasurementUnit { get; init; }
    public decimal IngredientCount { get; init; }
}
