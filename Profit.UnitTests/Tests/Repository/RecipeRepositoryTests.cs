namespace Profit.UnitTests.Tests.Repository;

public sealed class RecipeRepositoryTests
{
    [Theory]
    [@AutoData]
    public async Task Add_Entity_With_Valid_Data_Should_Count_One(
        Recipe recipe,
        Mock<ILogger<UnitOfWork>> loggerMock,
        Mock<IMigratorApplication> migrator)
    {
        // Arrange
        var unitOfWork = RepositoryFixtures.GetUnitOfWork(
            loggerMock,
            migrator);

        // Act        
        await unitOfWork.RecipeRepository.Add(recipe);
        await unitOfWork.Commit();

        // Assert
        //(await unitOfWork.RecipeRepository.CountAsync()).Should().Be(1);
    }

    [Theory]
    [@AutoData]
    public async Task GetUniqueAsync_ShouldReturnCachedEntityWhenAvailable(
        Recipe recipe,
        Mock<ILogger<UnitOfWork>> loggerMock,
        Mock<ICacheService> redisMock,
        Mock<IMigratorApplication> migrator)
    {
        // Arrange
        redisMock.Setup(c => c.GetAsync<Recipe>(It.IsAny<string>())).ReturnsAsync(recipe);
        var unitOfWork = RepositoryFixtures.GetUnitOfWork(
            loggerMock,
            migrator);

        // Act
        var entity = await unitOfWork.RecipeRepository.GetUniqueAsync(recipe.Id);

        // Assert
        Assert.Equal(recipe, entity);
        redisMock.Verify(c => c.GetAsync<Recipe>(It.IsAny<string>()), Times.Once());
        loggerMock.Verify(
            x => x.Log(
                It.Is<LogLevel>(x => x == LogLevel.Information),
                It.IsAny<EventId>(),
                It.IsAny<It.IsAnyType>(),
                It.IsAny<Exception>(),
                It.IsAny<Func<It.IsAnyType, Exception, string>>()),
            Times.Once);
    }

    [Theory]
    [@AutoData]
    public async Task GetUniqueAsync_ShouldReturnRepoEntityWhenCacheIsEmpty(
        Recipe recipe,
        Mock<ILogger<UnitOfWork>> loggerMock,
        Mock<ICacheService> redisMock,
        Mock<IMigratorApplication> migrator)
    {
        // Arrange
        redisMock.Setup(c => c.GetAsync<Recipe>(It.IsAny<string>())).ReturnsAsync((Recipe)null);
        var unitOfWork = RepositoryFixtures.GetUnitOfWork(
            loggerMock,
            migrator);

        await unitOfWork.RecipeRepository.Add(recipe);
        await unitOfWork.Commit();

        // Act
        var entity = await unitOfWork.RecipeRepository.GetUniqueAsync(recipe.Id);

        // Assert
        Assert.Equal(recipe, entity);
        redisMock.Verify(c => c.GetAsync<Recipe>(It.IsAny<string>()), Times.Once());
    }
}
