namespace Profit.Domain.DTOs;

public readonly record struct RecipeDto
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public decimal TotalCost { get; init; }
    public string Description { get; init; }
    public bool IsDeleted { get; init; }
    public ICollection<IngredientRecipeRelationDto> IngredientRecipeRelations { get; init; }
}