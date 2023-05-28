namespace Profit.Domain.Interfaces.Repositories.Base;

public interface IBaseRepository<TEntity> where TEntity : Entity<TEntity>
{
    public ValueTask Add(TEntity entity, CancellationToken cancellationToken = default);
    public void BulkAdd(IEnumerable<TEntity> ingredients);
    public void Update(TEntity entity);
    public void Delete(TEntity entity);
    public ValueTask<int> CountAsync(CancellationToken cancellationToken = default);
    public ValueTask<bool> ExistsAsync(TEntity entity, CancellationToken cancellationToken = default);
    public ValueTask<TEntity> GetUniqueAsync(Guid id, CancellationToken cancellationToken = default);
    public ValueTask<IEnumerable<TEntity>> GetManyAsync(CancellationToken cancellationToken = default);
    ValueTask<IEnumerable<TEntity>> GetManyByAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
    ValueTask<EntityQueryResultPaginated<TEntity>> GetByPaginated(
        Expression<Func<TEntity, bool>> predicate,
        int page,
        int pageSize,
        CancellationToken cancellationToken = default);

    ValueTask<int> CountByAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
}
