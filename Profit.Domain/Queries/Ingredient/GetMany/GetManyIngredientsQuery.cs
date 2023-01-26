namespace Profit.Domain.Queries.Ingredient.GetMany;

public readonly record struct GetManyIngredientsQuery : IRequest<IEnumerable<IngredientDTO>>
{
}