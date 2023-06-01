namespace Profit.Domain.Queries.User.Authenticate;

public sealed record AuthenticateUserQuery : IRequest<JwtToken>
{
    public string Username { get; init; }
    public string Password { get; set; }
}