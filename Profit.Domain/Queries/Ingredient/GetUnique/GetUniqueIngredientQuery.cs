namespace Profit.Domain.Queries.Ingredient.GetUnique;

public readonly record struct GetUniqueIngredientQuery : IRequest<IngredientDTO>
{
    public Guid Guid { get; }

    public GetUniqueIngredientQuery(Guid guid)
    {
        Guid = guid;
    }
}
