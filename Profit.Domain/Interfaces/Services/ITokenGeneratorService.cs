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

    /// <summary>
    /// Generate <see cref="Claim"/> from <see cref="UserClaim"/>
    /// </summary>
    /// <param name="userClaim"></param>
    /// <returns></returns>
    Claim GenerateClaim(UserClaim userClaim);

    /// <summary>
    /// Generate <see cref="Claim"/> from <see cref="UserClaim"/>
    /// </summary>
    /// <param name="userClaim"></param>
    /// <returns></returns>
    IEnumerable<Claim> GenerateClaim(IEnumerable<UserClaim> userClaims);
}
