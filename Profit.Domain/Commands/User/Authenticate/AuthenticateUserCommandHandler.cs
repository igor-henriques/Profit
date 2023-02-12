namespace Profit.Domain.Commands.User.Authenticate;

public sealed class AuthenticateUserCommandHandler : IRequestHandler<AuthenticateUserCommand, JwtToken>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPasswordHashingService _passwordHashingService;
    private readonly ITokenGeneratorService _tokenGeneratorService;

    public AuthenticateUserCommandHandler(
        IUnitOfWork unitOfWork,
        IPasswordHashingService passwordHashingService,
        ITokenGeneratorService tokenGeneratorService)
    {
        _unitOfWork = unitOfWork;
        _passwordHashingService = passwordHashingService;
        _tokenGeneratorService = tokenGeneratorService;
    }

    public async Task<JwtToken> Handle(AuthenticateUserCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var user = await _unitOfWork.UserRepository.GetByUsername(request.Username);

            var isPasswordMatch = _passwordHashingService.VerifyPassword(request.Password, user.HashedPassword);
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
