namespace Profit.Domain.Commands.Ingredient.Patch;

public sealed record PatchIngredientCommand : BaseCommand, IRequest<Unit>
{
    public Guid IngredientGuid { get; init; }
    public IngredientDTO Ingredient { get; init; }
}
