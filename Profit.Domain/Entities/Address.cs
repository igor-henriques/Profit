namespace Profit.Domain.Entities;

public sealed record Address : Entity<Address>
{
    public Guid? CustomerId { get; init; }
    public Guid? OrderId { get; init; }
    public string Street { get; init; }
    public string City { get; init; }
    public string State { get; init; }
    public string ZipCode { get; init; }
    public string Country { get; init; }
    public string Reference { get; init; }
    public string Observation { get; init; }

    public override Address Update(Address entity)
    {
        throw new NotImplementedException();
    }

    public override void Validate()
    {
        throw new NotImplementedException();
    }
}
