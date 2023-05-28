namespace Profit.UnitTests.Tests.Services;

public sealed class TokenGeneratorServiceTests
{
    private readonly Mock<IOptions<JwtAuthenticationOptions>> _jwtOptionsMock;
    private readonly TokenGeneratorService _tokenGeneratorService;

    public TokenGeneratorServiceTests()
    {
        _jwtOptionsMock = new Mock<IOptions<JwtAuthenticationOptions>>();
        _jwtOptionsMock.Setup(x => x.Value).Returns(new JwtAuthenticationOptions
        {
            Key = Guid.NewGuid().ToString(),
            TokenHoursDuration = 2
        });

        _tokenGeneratorService = new TokenGeneratorService(_jwtOptionsMock.Object);
    }

    [Fact]
    public void GenerateToken_WithClaims_ShouldReturnJwtToken()
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, "Test User"),
            new Claim(ClaimTypes.Email, "test@example.com")
        };

        var token = _tokenGeneratorService.GenerateToken(claims);

        Assert.True(token != default);
        Assert.NotEmpty(token.Token);
        Assert.True(token.ExpiresAt > DateTime.UtcNow);
    }

    [Fact]
    public void GenerateToken_WithoutClaims_ShouldReturnJwtToken()
    {
        var token = _tokenGeneratorService.GenerateToken((IEnumerable<Claim>)null);

        Assert.True(token != default);
        Assert.NotEmpty(token.Token);
        Assert.True(token.ExpiresAt > DateTime.UtcNow);
    }

    [Fact]
    public void GenerateToken_WithoutClaim_ShouldReturnJwtToken()
    {
        var token = _tokenGeneratorService.GenerateToken((Claim)null);

        Assert.True(token != default);
        Assert.NotEmpty(token.Token);
        Assert.True(token.ExpiresAt > DateTime.UtcNow);
    }

    [Fact]
    public void GenerateToken_SingleClaim_ShouldReturnJwtToken()
    {
        var claim = new Claim(ClaimTypes.Name, "Test User");

        var token = _tokenGeneratorService.GenerateToken(claim);

        Assert.True(token != default);
        Assert.NotEmpty(token.Token);
        Assert.True(token.ExpiresAt > DateTime.UtcNow);
    }

    [Fact]
    public void GenerateClaim_UserClaim_ShouldReturnClaim()
    {
        var userClaim = new UserClaim
        {
            ClaimType = ClaimTypes.Name,
            ClaimValue = "Test User"
        };

        var claim = _tokenGeneratorService.GenerateClaim(userClaim);

        Assert.NotNull(claim);
        Assert.Equal(userClaim.ClaimType, claim.Type);
        Assert.Equal(userClaim.ClaimValue, claim.Value);
    }

    [Fact]
    public void GenerateClaim_MultipleUserClaims_ShouldReturnClaims()
    {
        var userClaims = new List<UserClaim>
        {
            new UserClaim
            {
                ClaimType = ClaimTypes.Name,
                ClaimValue = "Test User"
            },
            new UserClaim
            {
                ClaimType = ClaimTypes.Email,
                ClaimValue = "test@example.com"
            }
        };

        var claims = _tokenGeneratorService.GenerateClaim(userClaims);

        Assert.NotNull(claims);
        Assert.Equal(userClaims.Count, claims.Count());
        Assert.All(claims, claim =>
        {
            var userClaim = userClaims.First(x => x.ClaimType == claim.Type);
            Assert.Equal(userClaim.ClaimValue, claim.Value);
        });
    }
}
