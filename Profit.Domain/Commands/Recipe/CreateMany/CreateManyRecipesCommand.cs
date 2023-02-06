namespace Profit.Domain.Commands.Recipe.CreateMany;

public sealed record CreateManyRecipesCommand : BaseCommand, IRequest<IEnumerable<Guid>>
{
    public IEnumerable<CreateRecipeDTO> Recipes { get; init; }
}
