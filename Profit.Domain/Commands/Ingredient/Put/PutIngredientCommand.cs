namespace Profit.Domain.Commands.Ingredient.Put;

public sealed record PutIngredientCommand : BaseCommand, IRequest<Unit>
{
    public Guid IngredientGuid { get; init; }
    public IngredientDTO Ingredient { get; init; }
}
