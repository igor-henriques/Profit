namespace Profit.Domain.Entities;

public sealed record IngredientRecipeRelation : Entity
{
    public Guid IngredientId { get; init; }
    public Ingredient Ingredient { get; init; }
    public Guid RecipeId { get; init; }
    public Recipe Recipe { get; init; }
    public EMeasurementUnit MeasurementUnit { get; init; }
    public decimal IngredientCount { get; init; }

    public override void Validate()
    {
        throw new NotImplementedException();
    }
}