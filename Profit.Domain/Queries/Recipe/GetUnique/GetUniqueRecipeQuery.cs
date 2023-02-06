namespace Profit.Domain.Queries.Recipe.GetUnique;

public readonly record struct GetUniqueRecipeQuery : IRequest<RecipeDTO>
{
    public Guid Id { get; }

    public GetUniqueRecipeQuery(Guid id)
    {
        Id = id;
    }
}
