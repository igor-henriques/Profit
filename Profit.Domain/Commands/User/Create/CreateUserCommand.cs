namespace Profit.Domain.Commands.User.Create;

public sealed record CreateUserCommand : IRequest<Guid>
{
    
    public string Username { get; init; }
    public string Email { get; init; }
    public string Password { get; init; }
}
