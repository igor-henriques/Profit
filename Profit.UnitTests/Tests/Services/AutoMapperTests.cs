namespace Profit.UnitTests.Tests.Services;

public sealed class AutoMapperTests
{
    [Fact]
    public void Validate_AutoMapper_Profiles()
    {
        // Arrange
        var configuration = new MapperConfiguration(cfg =>
        {
            cfg.AddMaps(typeof(UserProfile).Assembly);
            cfg.AddMaps(typeof(ProductProfile).Assembly);
            cfg.AddMaps(typeof(RecipeProfile).Assembly);
            cfg.AddMaps(typeof(IngredientProfile).Assembly);
            cfg.Internal().AllowAdditiveTypeMapCreation = true;
        });

        // Act and Assert
        configuration.AssertConfigurationIsValid();
    }
}
