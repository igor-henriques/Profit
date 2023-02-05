namespace Profit.Domain.DTOs.Create;

public readonly record struct CreateRecipeDTO
{
    public string Name { get; init; }
    public decimal TotalCost { get; init; }
    public string Description { get; init; }
    public ICollection<IngredientRecipeRelation> IngredientRecipeRelations { get; init; }
}
