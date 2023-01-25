namespace Profit.Domain.Entities.Base;

public abstract record Entity
{
    public Guid Guid { get; init; }
}
