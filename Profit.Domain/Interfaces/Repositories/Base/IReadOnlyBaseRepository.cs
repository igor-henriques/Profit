namespace Profit.Domain.Interfaces.Repositories.Base;

/// <summary>
/// All readonly repositories SHOULD NOT implement data changes methods.
/// All readonly repositories SHOULD implement AsNoTracking
/// </summary>
/// <typeparam name="TEntity"></typeparam>
public interface IReadOnlyBaseRepository<TEntity> where TEntity : Entity<TEntity>
{
    ValueTask<int> CountByAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
    ValueTask<bool> Exists(TEntity entity, CancellationToken cancellationToken = default);
    ValueTask<EntityQueryResultPaginated<TEntity>> GetByPaginated(Expression<Func<TEntity, bool>> predicate, int page, int pageSize, CancellationToken cancellationToken = default);
    ValueTask<IEnumerable<TEntity>> GetManyAsync(CancellationToken cancellationToken = default);
    ValueTask<IEnumerable<TEntity>> GetManyByAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
    ValueTask<TEntity> GetUniqueAsync(Guid id, CancellationToken cancellationToken = default);
    ValueTask<TEntity> GetUniqueByAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
}