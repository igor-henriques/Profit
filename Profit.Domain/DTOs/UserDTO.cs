namespace Profit.Domain.DTOs;

public readonly record struct UserDTO
{
    public Guid Guid { get; init; }
    public string Name { get; init; }
    public string Email { get; init; }
    public string Password { get; init; }
    public IEnumerable<Claim> Claims { get; init; }
}