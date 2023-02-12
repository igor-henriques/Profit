namespace Profit.Domain.Commands.User.Authenticate;

public sealed record AuthenticateUserCommand : IRequest<JwtToken>
{
    public string Username { get; init; }
    public string Password { get; set; }
}