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
        var changeCount = await unitOfWork.Commit();

        // Assert
        changeCount.Should().Be(4);
    }

    [Theory]
    [@AutoData]
    public async Task GetUniqueAsync_ShouldReturnCachedEntity_WhenAvailable(
       Recipe recipe,
       Mock<ILogger<CachedReadOnlyRecipeRepository>> loggerMock,
       Mock<ICacheService> cacheServiceMock,
       Mock<IOptions<CacheOptions>> cacheOptionsMock,
       Mock<ITenantInfo> tenantMock,
       Mock<IReadOnlyRecipeRepository> readOnlyRecipeRepoMock)
    {
        // Arrange
        cacheServiceMock.Setup(c => c.GetAsync<Recipe>(It.IsAny<string>())).ReturnsAsync(recipe);

        var cachedReadOnlyRecipeRepository = new CachedReadOnlyRecipeRepository(
            loggerMock.Object,
            cacheServiceMock.Object,
            cacheOptionsMock.Object,
            tenantMock.Object,
            readOnlyRecipeRepoMock.Object);

        // Act
        var entity = await cachedReadOnlyRecipeRepository.GetUniqueAsync(recipe.Id);

        // Assert
        Assert.Equal(recipe, entity);
        readOnlyRecipeRepoMock.Verify(x => x.GetUniqueAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()), Times.Never());
        cacheServiceMock.Verify(c => c.GetAsync<Recipe>(It.IsAny<string>()), Times.Once());
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
        Mock<ILogger<CachedReadOnlyRecipeRepository>> loggerMock,
        Mock<ICacheService> cacheServiceMock,
        Mock<IOptions<CacheOptions>> cacheOptionsMock,
        Mock<ITenantInfo> tenantMock,
        Mock<IReadOnlyRecipeRepository> readOnlyRecipeRepoMock)
    {
        // Arrange
        cacheOptionsMock.Setup(x => x.Value).Returns(new CacheOptions());
        cacheServiceMock.Setup(c => c.GetAsync<Recipe>(It.IsAny<string>())).ReturnsAsync((Recipe)null);
        readOnlyRecipeRepoMock.Setup(x => x.GetUniqueAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>())).ReturnsAsync(recipe);

        var cachedReadOnlyRecipeRepository = new CachedReadOnlyRecipeRepository(
            loggerMock.Object,
            cacheServiceMock.Object,
            cacheOptionsMock.Object,
            tenantMock.Object,
            readOnlyRecipeRepoMock.Object);

        // Act
        var entity = await cachedReadOnlyRecipeRepository.GetUniqueAsync(recipe.Id);

        // Assert
        Assert.Equal(recipe, entity);
        readOnlyRecipeRepoMock.Verify(x => x.GetUniqueAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()), Times.Once());
        cacheServiceMock.Verify(c => c.GetAsync<Recipe>(It.IsAny<string>()), Times.Once());
        cacheServiceMock.Verify(c => c.SetAsync(It.IsAny<string>(), recipe, It.IsAny<TimeSpan>()));
        loggerMock.Verify(
            x => x.Log(
                It.Is<LogLevel>(x => x == LogLevel.Information),
                It.IsAny<EventId>(),
                It.IsAny<It.IsAnyType>(),
                It.IsAny<Exception>(),
                It.IsAny<Func<It.IsAnyType, Exception, string>>()),
            Times.Once);
    }
}
