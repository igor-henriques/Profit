namespace Profit.Domain.Commands.Recipe.Create;

public sealed record CreateRecipeCommand : IRequest<Guid>
{
    public string Name { get; init; }
    public decimal TotalCost { get; init; }
    public string Description { get; init; }
    public ICollection<IngredientRecipeRelation> IngredientRecipeRelations { get; init; }
}