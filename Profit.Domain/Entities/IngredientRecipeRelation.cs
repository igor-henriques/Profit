namespace Profit.Domain.Entities;

public sealed record IngredientRecipeRelation
{
    public Guid IngredientId { get; private set; }
    public Ingredient Ingredient { get; init; }
    public Guid RecipeId { get; private set; }
    public Recipe Recipe { get; init; }
    public EMeasurementUnit MeasurementUnit { get; private set; }
    public decimal IngredientCount { get; private set; }
    public decimal RelationCost { get; private set; }

    public IngredientRecipeRelation(
        Guid ingredientId,
        EMeasurementUnit measurementUnit,
        decimal ingredientCount,
        decimal relationCost,
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
        RelationCost = relationCost;

        Validate();
    }

    public IngredientRecipeRelation() { }

    public IngredientRecipeRelation Update(IngredientRecipeRelation incomingEntity)
    {
        UpdateIngredientId(incomingEntity.IngredientId);
        UpdateIngredientCount(incomingEntity.IngredientCount);
        UpdateMeasurementUnit(incomingEntity.MeasurementUnit);
        UpdateRecipeId(incomingEntity.RecipeId);

        return this;
    }

    public IngredientRecipeRelation UpdateIngredientId(Guid incomingIngredientId)
    {
        ArgumentValidator.ThrowIfNullOrDefault(incomingIngredientId, nameof(incomingIngredientId));

        if (IngredientId != incomingIngredientId)
        {
            IngredientId = incomingIngredientId;
        }

        return this;
    }

    public IngredientRecipeRelation UpdateRecipeId(Guid incomingRecipeId)
    {
        ArgumentValidator.ThrowIfNullOrDefault(incomingRecipeId, nameof(incomingRecipeId));

        if (RecipeId != incomingRecipeId)
        {
            RecipeId = incomingRecipeId;
        }

        return this;
    }

    public IngredientRecipeRelation UpdateIngredientCount(decimal incomingIngredientCount)
    {
        ArgumentValidator.ThrowIfNegative(incomingIngredientCount, nameof(incomingIngredientCount));
        ArgumentValidator.ThrowIfZero(incomingIngredientCount, nameof(incomingIngredientCount));

        if (IngredientCount != incomingIngredientCount)
        {
            IngredientCount = incomingIngredientCount;
        }

        return this;
    }

    public IngredientRecipeRelation UpdateMeasurementUnit(EMeasurementUnit incomingMeasurementUnit)
    {
        if (MeasurementUnit != incomingMeasurementUnit)
        {
            MeasurementUnit.CheckForInvalidConversions(incomingMeasurementUnit);
            MeasurementUnit = incomingMeasurementUnit;
        }

        return this;
    }

    public IngredientRecipeRelation UpdateRelationCost(decimal incomingRelationCost)
    {
        ArgumentValidator.ThrowIfNegative(incomingRelationCost, nameof(incomingRelationCost));

        if (RelationCost != incomingRelationCost)
        {
            RelationCost = incomingRelationCost;
        }

        return this;
    }

    public void Validate()
    {
        ArgumentValidator.ThrowIfZeroOrNegative(IngredientCount, nameof(IngredientCount));
        ArgumentValidator.ThrowIfNullOrDefault(IngredientId, nameof(IngredientId));
    }
}