namespace Profit.Domain.Commands.Recipe.Create;

public sealed record CreateRecipeCommand : BaseCommand, IRequest<Guid>
{
    public CreateRecipeDTO Recipe { get; init; }
}