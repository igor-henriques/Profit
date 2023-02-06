namespace Profit.Domain.Commands.Recipe.Patch;

public sealed record PatchRecipeCommand : BaseCommand, IRequest<Unit>
{
    public RecipeDTO Recipe { get; init; }
}
