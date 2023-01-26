namespace Profit.Domain.Commands.Ingredient.Patch;

public sealed record PatchIngredientCommand : BaseCommand, IRequest<Unit>
{
    public Guid Guid { get; init; }
    public IngredientDTO Ingredient { get; init; }
}
