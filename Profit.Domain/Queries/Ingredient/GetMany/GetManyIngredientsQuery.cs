namespace Profit.Domain.Queries.Ingredient.GetPaginated;

public readonly record struct GetPaginatedIngredientsQuery : IQuery<IEnumerable<IngredientDto>>
{
}