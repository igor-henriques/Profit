namespace Profit.Domain.Entities;

public sealed record User : Entity
{
    public string Username { get; init; }
    public string HashedPassword { get; init; }
    public string Email { get; init; }
    public bool IsEmailVerified { get; init; }

    public ICollection<UserClaim> UserClaims { get; } = new List<UserClaim>();

    public override void Validate()
    {
        throw new NotImplementedException();
    }
}
