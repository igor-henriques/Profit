namespace Profit.Domain.Commands.Ingredient.Delete;

public sealed record DeleteIngredientCommand : IRequest<Unit>
{
    public Guid IngredientId { get; init; }
}
