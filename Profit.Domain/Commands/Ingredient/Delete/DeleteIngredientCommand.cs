namespace Profit.Domain.Commands.Ingredient.Delete;

public sealed record DeleteIngredientCommand : BaseCommand, IRequest<Unit>
{
    public Guid IngredientGuid { get; init; }
}
