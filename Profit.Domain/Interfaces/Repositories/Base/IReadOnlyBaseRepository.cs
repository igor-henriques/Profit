namespace Profit.Domain.Interfaces.Repositories.Base;

/// <summary>
/// All readonly repositories SHOULD NOT implement data changes methods.
/// All readonly repositories SHOULD implement AsNoTracking
/// </summary>
/// <typeparam name="TEntity"></typeparam>
public interface IReadOnlyBaseRepository<TEntity> where TEntity : Entity<TEntity>, IEntity
{
    ValueTask<int> CountAsync(CancellationToken cancellationToken = default);
    ValueTask<int> CountByAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
    ValueTask<bool> ExistsAsync(TEntity entity, CancellationToken cancellationToken = default);
    ValueTask<EntityQueryResultPaginated<TEntity>> GetByPaginatedAsync(Expression<Func<TEntity, bool>> predicate, BasePaginatedQuery basePaginated, CancellationToken cancellationToken = default);
    ValueTask<EntityQueryResultPaginated<TEntity>> GetPaginatedAsync(BasePaginatedQuery basePaginated, CancellationToken cancellationToken = default);
    ValueTask<TEntity> GetUniqueAsync(Guid id, CancellationToken cancellationToken = default);
    ValueTask<TEntity> GetUniqueByAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
}