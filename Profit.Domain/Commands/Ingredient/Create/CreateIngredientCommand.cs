namespace Profit.Domain.Commands.Ingredient.Create;

public sealed record CreateIngredientCommand : BaseCommand, IRequest<Guid>
{
    public CreateIngredientDTO Ingredient { get; init; }
}