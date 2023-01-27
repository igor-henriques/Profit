namespace Profit.Domain.Commands.Ingredient.Put;

public sealed record PutIngredientCommand : BaseCommand, IRequest<Unit>
{
    public IngredientDTO Ingredient { get; init; }
}
