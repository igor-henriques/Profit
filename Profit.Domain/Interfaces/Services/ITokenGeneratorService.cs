namespace Profit.Domain.Interfaces.Services;

public interface ITokenGeneratorService
{
    JwtToken GenerateToken(User user = null);
}
