namespace Profit.Domain.Commands.Recipe.Put;

public sealed record PutRecipeCommand : BaseCommand, IRequest<Unit>
{
    public RecipeDTO Recipe { get; init; }
}
