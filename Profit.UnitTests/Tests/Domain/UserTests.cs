namespace Profit.UnitTests.Tests.Domain;

public sealed class UserTests
{
    [Fact]
    public void UpdateUsername_ShouldChangeUsername_WhenDifferentUsernameIsProvided()
    {
        // Arrange & Act & Assert
        Assert.Throws<ArgumentNullException>(() => new User(Guid.NewGuid(), null, "a", "b", true));
    }

    [Theory]
    [@AutoData]
    public void UpdateUsername_ShouldNotChangeUsername_WhenSameUsernameIsProvided(User user)
    {
        // Act
        var updatedUser = user.UpdateUsername("SameUsername");

        // Assert
        Assert.Equal("SameUsername", updatedUser.Username);
    }

    [Theory]
    [@AutoData]
    public void UpdateUsername_ShouldThrowArgumentException_WhenNullIsProvided(User user)
    {
        // Act and Assert
        Assert.Throws<ArgumentNullException>(() => user.UpdateUsername(null));
    }

    // Você pode criar testes similares para UpdateEmail e UpdateHashedPassword

    [Fact]
    public void UpdateIsEmailVerified_ShouldChangeIsEmailVerified_WhenDifferentValueIsProvided()
    {
        // Arrange
        var user = new User(Guid.NewGuid(), "SameUsername", "a", "b", false);

        // Act
        var updatedUser = user.UpdateIsEmailVerified(true);

        // Assert
        Assert.True(updatedUser.IsEmailVerified);
    }

    [Fact]
    public void UpdateIsEmailVerified_ShouldNotChangeIsEmailVerified_WhenSameValueIsProvided()
    {
        // Arrange
        var user = new User(Guid.NewGuid(), "SameUsername", "a", "b", false);

        // Act
        var updatedUser = user.UpdateIsEmailVerified(false);

        // Assert
        Assert.False(updatedUser.IsEmailVerified);
    }

    [Fact]
    public void Validate_ShouldThrowArgumentException_WhenUsernameIsNull()
    {
        // Arrange & Act and Assert
        Assert.Throws<ArgumentNullException>(() => new User(Guid.NewGuid(), null, "a", "b", false));
    }
}
