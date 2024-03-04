namespace Profit.Domain.Entities.Base;

public abstract record Entity<T> where T : Entity<T>, IEntity
{
    public Guid Id { get; init; }
    public DateTime? UpdatedAt { get; set; }
    public bool IsDeleted { get; private set; }
    public abstract void Validate();
    public abstract T Update(T entity);
    public virtual void Delete()
    {
        IsDeleted = true;
        UpdatedAt = DateTime.Now;
    }
    public virtual void Undelete()
    {
        IsDeleted = false;
        UpdatedAt = DateTime.Now;
    }
}
