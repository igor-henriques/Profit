namespace Profit.Domain.Entities;

public sealed record IngredientRecipeRelation
{
    public Guid IngredientId { get; private set; }
    public Ingredient Ingredient { get; init; }
    public Guid RecipeId { get; private set; }
    public Recipe Recipe { get; init; }
    public EMeasurementUnit MeasurementUnit { get; private set; }
    public decimal IngredientCount { get; private set; }

    public IngredientRecipeRelation(
        Guid ingredientId,                
        EMeasurementUnit measurementUnit,
        decimal ingredientCount,
        Guid? recipeId = null,
        Recipe recipe = null,
        Ingredient ingredient = null)
    {
        IngredientId = ingredientId;
        Ingredient = ingredient;
        RecipeId = recipeId ?? Guid.Empty;
        Recipe = recipe;
        MeasurementUnit = measurementUnit;
        IngredientCount = ingredientCount;

        Validate();
    }

    public IngredientRecipeRelation() { }

    public IngredientRecipeRelation Update(IngredientRecipeRelation entity)
    {
        UpdateIngredientId(entity.IngredientId);
        UpdateIngredientCount(entity.IngredientCount);
        UpdateMeasurementUnit(entity.MeasurementUnit);
        UpdateRecipeId(entity.RecipeId);

        return this;
    }

    public IngredientRecipeRelation UpdateIngredientId(Guid ingredientId)
    {
        ArgumentValidator.ThrowIfNullOrDefault(ingredientId, nameof(ingredientId));

        if (IngredientId != ingredientId)
        {
            IngredientId = ingredientId;
        }

        return this;
    }

    public IngredientRecipeRelation UpdateRecipeId(Guid recipeId)
    {
        RecipeId = recipeId;
        return this;
    }

    public IngredientRecipeRelation UpdateIngredientCount(decimal ingredientCount)
    {
        ArgumentValidator.ThrowIfNegative(ingredientCount, nameof(ingredientCount));
        ArgumentValidator.ThrowIfZero(ingredientCount, nameof(ingredientCount));

        if (IngredientCount != ingredientCount)
        {
            IngredientCount = ingredientCount;
        }

        return this;
    }

    public IngredientRecipeRelation UpdateMeasurementUnit(EMeasurementUnit measurementUnit)
    {
        if (MeasurementUnit != measurementUnit)
        {
            MeasurementUnit = measurementUnit;
        }

        return this;
    }

    public void Validate()
    {        
        ArgumentValidator.ThrowIfZeroOrNegative(IngredientCount, nameof(IngredientCount));
        ArgumentValidator.ThrowIfNullOrDefault(IngredientId, nameof(IngredientId));        
    }
}