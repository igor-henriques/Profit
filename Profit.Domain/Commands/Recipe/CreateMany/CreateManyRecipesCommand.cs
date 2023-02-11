namespace Profit.Domain.Commands.Recipe.CreateMany;

public sealed record CreateManyRecipesCommand : IRequest<IEnumerable<Guid>>
{
    public IEnumerable<CreateRecipeCommand> Recipes { get; init; }
}
