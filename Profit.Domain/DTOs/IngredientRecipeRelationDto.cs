namespace Profit.Domain.DTOs;

public readonly record struct IngredientRecipeRelationDto
{
    public Guid IngredientId { get; init; }
    public EMeasurementUnit MeasurementUnit { get; init; }
    public decimal IngredientCount { get; init; }
}
