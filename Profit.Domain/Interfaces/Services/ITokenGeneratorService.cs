namespace Profit.Domain.Interfaces.Services;

public interface ITokenGeneratorService
{
    JwtToken GenerateToken(Claim claim = null);
    JwtToken GenerateToken(IEnumerable<Claim> claims = null);
}
