namespace Profit.Domain.Commands.Ingredient.CreateMany;

public sealed record CreateManyIngredientsCommand : BaseCommand, IRequest<IEnumerable<Guid>>
{
    public IEnumerable<IngredientDTO> Ingredients { get; init; }
}
