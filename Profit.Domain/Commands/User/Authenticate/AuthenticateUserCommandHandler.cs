namespace Profit.Domain.Commands.User.Authenticate;

public sealed class AuthenticateUserCommandHandler : IRequestHandler<AuthenticateUserCommand, JwtToken>
{
    private readonly IPasswordHashingService _passwordHashingService;
    private readonly ITokenGeneratorService _tokenGeneratorService;
    private readonly IReadOnlyUserRepository _readOnlyRepo;

    public AuthenticateUserCommandHandler(
        IPasswordHashingService passwordHashingService,
        ITokenGeneratorService tokenGeneratorService,
        IReadOnlyUserRepository readOnlyRepo)
    {
        _passwordHashingService = passwordHashingService;
        _tokenGeneratorService = tokenGeneratorService;
        _readOnlyRepo = readOnlyRepo;
    }

    public async Task<JwtToken> Handle(AuthenticateUserCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var user = await _readOnlyRepo.GetByUsername(request.Username, cancellationToken);

            var isPasswordMatch = _passwordHashingService.VerifyPassword(user.HashedPassword, request.Password);
            if (!isPasswordMatch)
            {
                throw new InvalidCredentialsException($"Authentication failed for username {request.Username}");
            }

            var claims = _tokenGeneratorService.GenerateClaim(user.UserClaims);
            var token = _tokenGeneratorService.GenerateToken(claims);

            return token;
        }
        catch (EntityNotFoundException)
        {
            throw new InvalidCredentialsException($"Authentication failed for username {request.Username}");
        }
    }
}
