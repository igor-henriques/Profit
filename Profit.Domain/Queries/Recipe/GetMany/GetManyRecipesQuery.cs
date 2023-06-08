namespace Profit.Domain.Queries.Recipe.GetPaginated;

public readonly record struct GetPaginatedRecipesQuery : IQuery<IEnumerable<RecipeDto>>
{
}