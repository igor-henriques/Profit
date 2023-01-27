namespace Profit.Domain.Commands.Ingredient.Patch;

public sealed record PatchIngredientCommand : BaseCommand, IRequest<Unit>
{
    public IngredientDTO Ingredient { get; init; }
}
