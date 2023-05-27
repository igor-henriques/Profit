namespace Profit.Domain.Interfaces.Repositories;

public interface IRecipeRepository : IBaseRepository<Recipe>
{
    Task<IEnumerable<Recipe>> GetRecipesAndRelationsByIngredientId(
       Guid ingredientId,
       CancellationToken cancellationToken = default);
}
