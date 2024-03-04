namespace Profit.Application.Commands.Recipe.Put;

public sealed record PutRecipeCommand : IRequest<Unit>
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public string Description { get; init; }
    public bool IsDeleted { get; init; }
    public ICollection<IngredientRecipeRelationDto> IngredientRecipeRelations { get; init; }
}
