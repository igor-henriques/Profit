namespace Profit.Application.Queries.Ingredient.GetPaginated;

public sealed record GetPaginatedIngredientsQuery : BasePaginatedQuery, IQuery<EntityQueryResultPaginated<IngredientDto>>
{
    public GetPaginatedIngredientsQuery(int pageNumber, int itemsPerPage) : base(pageNumber, itemsPerPage)
    {
    }
}