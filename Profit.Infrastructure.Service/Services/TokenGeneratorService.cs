using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Profit.Domain.Entities;
using Profit.Domain.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Profit.Infrastructure.Service.Services;

public sealed class TokenGeneratorService : ITokenGeneratorService
{
    private readonly string _tokenKey;
    private readonly int tokenHoursDuration;

    public TokenGeneratorService(IConfiguration configuration)
    {
        this._tokenKey = configuration.GetSection("JwtBearerKey").Value;
        this.tokenHoursDuration = int.Parse(configuration.GetSection("TokenHoursDuration").Value);
    }

    public JwtToken GenerateToken(User user = null)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_tokenKey);
        var expiresAt = DateTime.UtcNow.AddHours(tokenHoursDuration);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Expires = expiresAt,
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        if (user != null)
            tokenDescriptor.Subject = new ClaimsIdentity(GetClaims(user.Claims.Select(x => x.Value)));

        var token = tokenHandler.CreateToken(tokenDescriptor);

        var jwt = tokenHandler.WriteToken(token);

        return new JwtToken
        {
            Token = jwt,
            ExpiresAt = expiresAt
        };
    }

    private static IEnumerable<Claim> GetClaims(IEnumerable<string> roles)
    {
        foreach (var role in roles)
        {
            yield return new Claim(ClaimTypes.Role, role);
        }
    }
}