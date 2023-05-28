namespace Profit.Domain.Entities.Base;

public abstract record Entity<T> where T : Entity<T>
{
    public Guid Id { get; init; }
    public bool IsDeleted { get; private set; }
    public abstract void Validate();
    public abstract T Update(T entity);
    public virtual Entity<T> Delete()
    {
        IsDeleted = true;
        return (T)this;
    }
    public virtual Entity<T> Undelete()
    {
        IsDeleted = false;
        return (T)this;
    }
}
