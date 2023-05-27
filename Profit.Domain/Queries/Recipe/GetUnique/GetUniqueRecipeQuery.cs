namespace Profit.Domain.Queries.Recipe.GetUnique;

public readonly record struct GetUniqueRecipeQuery : IQuery<RecipeDto>
{
    public Guid Id { get; }

    public GetUniqueRecipeQuery(Guid id)
    {
        Id = id;
    }
}
