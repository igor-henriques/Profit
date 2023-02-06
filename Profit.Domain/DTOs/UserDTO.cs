namespace Profit.Domain.DTOs;

public readonly record struct UserDTO
{
    public Guid Id { get; init; }
    public string Username { get; init; }
    public string Email { get; init; }
    public string Password { get; init; }
}