namespace Profit.Domain.Queries.Recipe.GetMany;

public readonly record struct GetManyRecipesQuery : IQuery<IEnumerable<RecipeDTO>>
{
}