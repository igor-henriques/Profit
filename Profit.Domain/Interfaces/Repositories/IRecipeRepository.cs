namespace Profit.Domain.Interfaces.Repositories;

public interface IRecipeRepository : IBaseRepository<Recipe>
{
    Task<IEnumerable<IngredientRecipeRelation>> GetIngredientRecipeRelationByIngredientId(
       Guid ingredientId,
       CancellationToken cancellationToken = default);
}
