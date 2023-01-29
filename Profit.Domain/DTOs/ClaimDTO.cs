namespace Profit.Domain.DTOs;

public readonly record struct ClaimDTO
{
    public Guid Subject { get; init; }
    public string Value { get; init; }
    public DateTime? CreatedAt { get; init; }
    public DateTime? UpdatedAt { get; init; }
    public DateTime? ExpiresAt { get; init; }
    public DateTime? RevokedAt { get; init; }
}
