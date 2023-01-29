namespace Profit.Infrastructure.Service.Services;

public sealed class TokenGeneratorService : ITokenGeneratorService
{
    private readonly string _tokenKey;
    private readonly int tokenHoursDuration;

    public TokenGeneratorService(IConfiguration configuration)
    {
        this._tokenKey = configuration.GetSection("JwtAuthentication:Key").Value;
        this.tokenHoursDuration = int.Parse(configuration.GetSection("JwtAuthentication:TokenHoursDuration").Value);
    }

    public JwtToken GenerateToken(IEnumerable<Claim> claims = null)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_tokenKey);
        var expiresAt = DateTime.UtcNow.AddHours(tokenHoursDuration);
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
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_tokenKey);
        var expiresAt = DateTime.UtcNow.AddHours(tokenHoursDuration);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Expires = expiresAt,
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        if (claim != null)
            tokenDescriptor.Subject = new ClaimsIdentity(new List<Claim>() { claim });

        var token = tokenHandler.CreateToken(tokenDescriptor);

        var jwt = tokenHandler.WriteToken(token);

        return new JwtToken
        {
            Token = jwt,
            ExpiresAt = expiresAt
        };
    }
}