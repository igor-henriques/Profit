namespace Profit.Domain.Interfaces.Repositories.Base;

public interface IBaseRepository<T> where T : Entity
{
    public ValueTask Add(T entity, CancellationToken cancellationToken = default);
    public void BulkAdd(IEnumerable<T> ingredients);
    public void Update(T entity);
    public void Delete(T entity);
    public ValueTask<bool> Exists(T entity, CancellationToken cancellationToken = default);
    public ValueTask<T> GetUniqueAsync(Guid id, CancellationToken cancellationToken = default);
    public ValueTask<IEnumerable<T>> GetManyAsync(CancellationToken cancellationToken = default);
}
