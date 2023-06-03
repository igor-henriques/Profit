namespace Profit.Domain.Entities;

public sealed record Customer : Entity<Customer>
{
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string Email { get; init; }
    public DateTime? BirthDate { get; init; }
    public string Document { get; init; }
    public Guid MainAddress { get; init; }
    public ICollection<Address> Addresses { get; init; }
    public ICollection<Order> Orders { get; init; }

    public override Customer Update(Customer entity)
    {
        throw new NotImplementedException();
    }

    public override void Validate()
    {
        throw new NotImplementedException();
    }
}
