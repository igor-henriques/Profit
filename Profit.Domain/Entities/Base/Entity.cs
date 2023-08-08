namespace Profit.Domain.Entities.Base;

public abstract record Entity<T> where T : Entity<T>
    {
    public Guid Id { get; init; }
    public DateTime? UpdatedAt { get; set; }
    public bool IsDeleted { get; private set; }
    public abstract void Validate();
    public abstract T Update(T entity);
    public virtual Entity<T> Delete()
    {
        IsDeleted = true;
        UpdatedAt = DateTime.Now;
        return (T)this;
    }
    public virtual Entity<T> Undelete()
    {
        IsDeleted = false;
        UpdatedAt = DateTime.Now;
        return (T)this;
    }
}
