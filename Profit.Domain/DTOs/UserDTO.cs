namespace Profit.Domain.DTOs;

public readonly record struct UserDTO
{
    public string Username { get; init; }
    public string Email { get; init; }
    public string HashedPassword { get; init; }
}