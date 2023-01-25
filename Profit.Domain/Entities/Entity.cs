namespace Profit.Domain.Entities;

public abstract record Entity
{
    public Guid Guid { get; init; }
}
