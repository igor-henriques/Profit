namespace Profit.Domain.Commands.Recipe.Delete;

public sealed record DeleteRecipeCommand : BaseCommand, IRequest<Unit>
{
    public Guid RecipeId { get; init; }
}
