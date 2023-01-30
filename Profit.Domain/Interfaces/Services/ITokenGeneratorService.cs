namespace Profit.Domain.Interfaces.Services;

/// <summary>
/// Provides an authentication token generator service.
/// </summary>
public interface ITokenGeneratorService
{
    /// <summary>
    /// Generates a new authentication token.
    /// </summary>
    /// <param name="claim"></param>
    /// <returns></returns>
    JwtToken GenerateToken(Claim claim = null);

    /// <summary>
    /// Generates a new authentication token.
    /// </summary>
    /// <param name="claims"></param>
    /// <returns></returns>
    JwtToken GenerateToken(IEnumerable<Claim> claims = null);
}
