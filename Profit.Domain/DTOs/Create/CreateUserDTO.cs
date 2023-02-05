namespace Profit.Domain.DTOs.Create;

public readonly record struct CreateUserDTO
{
    public string Username { get; init; }
    public string Email { get; init; }
    public string Password { get; init; }
}
