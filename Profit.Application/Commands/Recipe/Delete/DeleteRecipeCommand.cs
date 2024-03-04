namespace Profit.Application.Commands.Recipe.Delete;

public sealed record DeleteRecipeCommand : IRequest<Unit>
{
    public Guid RecipeId { get; init; }
}
