namespace Profit.Domain.Commands.Ingredient.Delete;

public sealed record DeleteIngredientCommand : BaseCommand, IRequest<Unit>
{
    public Guid IngredientId { get; init; }
}
