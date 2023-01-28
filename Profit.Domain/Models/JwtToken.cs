namespace Profit.Domain.Models;

public readonly record struct JwtToken
{
    public string Token { get; init; }
    public DateTime ExpiresAt { get; init; }
}
