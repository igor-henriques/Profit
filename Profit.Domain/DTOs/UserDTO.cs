namespace Profit.Domain.DTOs;

public readonly record struct UserDto
{
    public Guid Id { get; init; }
    public Guid TenantId { get; init; }
    public string Username { get; init; }
    public string Email { get; init; }
    public string Password { get; init; }
    public bool IsDeleted { get; init; }
}