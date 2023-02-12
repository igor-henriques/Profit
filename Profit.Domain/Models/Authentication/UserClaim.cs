namespace Profit.Domain.Models.Authentication;

public sealed record UserClaim
{
    public Guid Guid { get; init; }
    public string ClaimType { get; init; }
    public string ClaimValue { get; init; }
    public Guid UserId { get; init; }
    public User User { get; init; }
}
