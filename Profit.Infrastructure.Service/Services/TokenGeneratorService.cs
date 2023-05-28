namespace Profit.Infrastructure.Service.Services;

public sealed class TokenGeneratorService : ITokenGeneratorService
{
    private readonly IOptions<JwtAuthenticationOptions> _jwtOptions;

    public TokenGeneratorService(IOptions<JwtAuthenticationOptions> jwtOptions)
    {
        ArgumentValidator.ThrowIfNullOrDefault(jwtOptions.Value, nameof(jwtOptions));
        _jwtOptions = jwtOptions;
    }

    public JwtToken GenerateToken(IEnumerable<Claim> claims = null)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_jwtOptions.Value.Key);
        var expiresAt = DateTime.UtcNow.AddHours(_jwtOptions.Value.TokenHoursDuration);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Expires = expiresAt,
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        if (claims != null)
            tokenDescriptor.Subject = new ClaimsIdentity(claims);

        var token = tokenHandler.CreateToken(tokenDescriptor);

        var jwt = tokenHandler.WriteToken(token);

        return new JwtToken
        {
            Token = jwt,
            ExpiresAt = expiresAt
        };
    }

    public JwtToken GenerateToken(Claim claim = null)
    {
        return GenerateToken(claim != null ? new List<Claim>() { claim } : null);
    }

    public Claim GenerateClaim(UserClaim userClaim)
    {
        return new Claim(userClaim.ClaimType, userClaim.ClaimValue);
    }

    public IEnumerable<Claim> GenerateClaim(IEnumerable<UserClaim> userClaims)
    {
        return userClaims.Select(GenerateClaim);
    }
}