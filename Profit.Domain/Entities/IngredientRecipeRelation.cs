namespace Profit.Domain.Entities;

public sealed record IngredientRecipeRelation : Entity<IngredientRecipeRelation>
{
    public Guid IngredientId { get; private set; }
    public Ingredient Ingredient { get; init; }
    public Guid RecipeId { get; private set; }
    public Recipe Recipe { get; init; }
    public EMeasurementUnit MeasurementUnit { get; private set; }
    public decimal IngredientCount { get; private set; }

    public IngredientRecipeRelation(
        Guid ingredientId,
        Ingredient ingredient,
        Guid recipeId,
        Recipe recipe,
        EMeasurementUnit measurementUnit,
        decimal ingredientCount)
    {
        IngredientId = ingredientId;
        Ingredient = ingredient;
        RecipeId = recipeId;
        Recipe = recipe;
        MeasurementUnit = measurementUnit;
        IngredientCount = ingredientCount;

        Validate();
    }

    public IngredientRecipeRelation() { }

    public override IngredientRecipeRelation Update(IngredientRecipeRelation entity)
    {
        UpdateIngredientId(entity.IngredientId);
        UpdateIngredientCount(entity.IngredientCount);
        UpdateMeasurementUnit(entity.MeasurementUnit);
        UpdateRecipeId(entity.RecipeId);

        return this;
    }

    public void UpdateIngredientId(Guid ingredientId)
    {
        ArgumentValidator.ThrowIfNullOrDefault(ingredientId, nameof(ingredientId));

        if (IngredientId != ingredientId)
        {
            IngredientId = ingredientId;
        }
    }

    public void UpdateRecipeId(Guid recipeId)
    {
        ArgumentValidator.ThrowIfNullOrDefault(recipeId, nameof(recipeId));

        if (RecipeId != recipeId)
        {
            RecipeId = recipeId;
        }
    }

    public void UpdateIngredientCount(decimal ingredientCount)
    {
        ArgumentValidator.ThrowIfNegative(ingredientCount, nameof(ingredientCount));
        ArgumentValidator.ThrowIfZero(ingredientCount, nameof(ingredientCount));

        if (IngredientCount != ingredientCount)
        {
            IngredientCount = ingredientCount;
        }
    }

    public void UpdateMeasurementUnit(EMeasurementUnit measurementUnit)
    {
        if (MeasurementUnit != measurementUnit)
        {
            MeasurementUnit = measurementUnit;
        }
    }

    public override void Validate()
    {
        ArgumentValidator.ThrowIfNegative(IngredientCount, nameof(IngredientCount));
        ArgumentValidator.ThrowIfZero(IngredientCount, nameof(IngredientCount));
        ArgumentValidator.ThrowIfNullOrDefault(IngredientId, nameof(IngredientId));
        ArgumentValidator.ThrowIfNullOrDefault(RecipeId, nameof(RecipeId));
    }
}