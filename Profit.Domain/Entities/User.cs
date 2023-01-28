namespace Profit.Domain.Entities;

public record User : Entity
{
    public string Name { get; init; }
    public string Email { get; init; }
    public string Password { get; init; }
    public virtual IEnumerable<Claim> Claims { get; init; } 
}
