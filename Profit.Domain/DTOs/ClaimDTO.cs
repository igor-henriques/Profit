namespace Profit.Domain.DTOs;

public readonly record struct ClaimDto
{
    public Guid Guid { get; init; }
    public string ClaimType { get; init; }
    public string ClaimValue { get; init; }
    public Guid UserId { get; init; }
    public User User { get; init; }
}
