namespace Profit.Application.Commands.Recipe.Create;

public sealed record CreateRecipeCommand : IRequest<Guid>
{
    public string Name { get; init; }
    public string Description { get; init; }
    public ICollection<IngredientRecipeRelationDto> IngredientRecipeRelations { get; init; }
}