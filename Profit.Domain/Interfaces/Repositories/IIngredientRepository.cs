namespace Profit.Domain.Interfaces.Repositories;

public interface IIngredientRepository
{
    public void Add(Ingredient ingredient);
    public void BulkAdd(IEnumerable<Ingredient> ingredients);
    public void Update(Ingredient ingredient);
    public void Delete(Ingredient ingredient);
    public ValueTask<Ingredient> Get(Guid id, CancellationToken cancellationToken = default);
    public ValueTask<IEnumerable<Ingredient>> GetMany(CancellationToken cancellationToken = default);
}
