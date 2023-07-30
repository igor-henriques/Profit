namespace Profit.Domain.Queries.Recipe.GetPaginated;

public sealed record GetPaginatedRecipesQuery : BasePaginatedQuery, IQuery<EntityQueryResultPaginated<RecipeDto>>
{
    public GetPaginatedRecipesQuery(int pageNumber, int itemsPerPage) : base(pageNumber, itemsPerPage)
    {
    }
}