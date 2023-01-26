namespace Profit.Domain.Commands.Ingredient.Create;

public sealed record CreateIngredientCommand : BaseCommand, IRequest<Guid>
{
    public IngredientDTO Ingredient { get; init; }
}