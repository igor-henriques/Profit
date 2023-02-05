namespace Profit.Domain.Models.Authentication;

public readonly record struct JwtToken
{
    public string Token { get; init; }
    public DateTime ExpiresAt { get; init; }
}
