namespace Profit.Domain.Queries.Ingredient.GetMany;

public readonly record struct GetManyIngredientsQuery : IQuery<IEnumerable<IngredientDTO>>
{
}