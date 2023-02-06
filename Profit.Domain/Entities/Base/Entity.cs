namespace Profit.Domain.Entities.Base;

public abstract record Entity<T> where T : Entity<T>
{
    public Guid Id { get; init; }
    public abstract void Validate();
    public abstract T Update(T entity);
}
