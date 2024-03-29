﻿namespace Profit.Domain.Interfaces.Repositories.Base;

public interface IBaseRepository<TEntity> where TEntity : Entity<TEntity>, IEntity
{
    public ValueTask Add(TEntity entity, CancellationToken cancellationToken = default);
    public void BulkAdd(IEnumerable<TEntity> ingredients);
    public void Update(TEntity entity);
    public void Delete(TEntity entity);
    public ValueTask<TEntity> GetUniqueAsync(Guid id, CancellationToken cancellationToken = default);
    public ValueTask<IEnumerable<TEntity>> GetPaginatedAsync(CancellationToken cancellationToken = default);
    ValueTask<IEnumerable<TEntity>> GetPaginatedByAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
}
