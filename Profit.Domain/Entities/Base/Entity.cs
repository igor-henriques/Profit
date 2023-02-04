namespace Profit.Domain.Entities.Base;

public abstract record Entity
{
    public Guid Id { get; init; }
    public abstract void Validate();
}
