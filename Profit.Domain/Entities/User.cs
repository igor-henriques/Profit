namespace Profit.Domain.Entities;

public record User : Entity
{
    public string Username { get; init; }
    public string HashedPassword { get; init; }
    public string Email { get; init; }
    public bool IsEmailVerified { get; init; }

    public virtual ICollection<UserClaim> UserClaims { get; } = new List<UserClaim>();
}
