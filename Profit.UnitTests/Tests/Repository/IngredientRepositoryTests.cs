namespace Profit.UnitTests.Tests.Repository;

public sealed class IngredientRepositoryTests
{
    [Theory]
    [@AutoData]
    public async Task AddIngredient_WithValid_Data_ShouldCountOne(
        Ingredient ingredient,
        Mock<ILogger<UnitOfWork>> loggerMock,
        Mock<IMigratorApplication> migrator)
    {
        // Arrange
        var unitOfWork = RepositoryFixtures.GetUnitOfWork(
            loggerMock,
            migrator,
            "ingredient-db1");

        // Act
        await unitOfWork.IngredientRepository.Add(ingredient);
        var changeCount = await unitOfWork.Commit();

        // Assert
        changeCount.Should().Be(1);
    }

    [Theory]
    [@AutoData]
    public async Task GetUniqueAsync_ShouldReturnCachedEntity_WhenAvailable(
        Ingredient ingredient,
        Mock<ILogger<CachedReadOnlyIngredientRepository>> loggerMock,
        Mock<ICacheService> cacheServiceMock,
        Mock<IOptions<CacheOptions>> cacheOptionsMock,
        Mock<ITenantInfo> tenantMock,
        Mock<IReadOnlyIngredientRepository> readOnlyIngredientRepoMock)
    {
        // Arrange
        cacheServiceMock.Setup(c => c.GetAsync<Ingredient>(It.IsAny<string>())).ReturnsAsync(ingredient);

        var cachedReadOnlyIngredientRepository = new CachedReadOnlyIngredientRepository(
            loggerMock.Object,
            cacheServiceMock.Object,
            cacheOptionsMock.Object,
            tenantMock.Object,
            readOnlyIngredientRepoMock.Object);

        // Act
        var entity = await cachedReadOnlyIngredientRepository.GetUniqueAsync(ingredient.Id);

        // Assert
        Assert.Equal(ingredient, entity);
        readOnlyIngredientRepoMock.Verify(x => x.GetUniqueAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()), Times.Never());
        cacheServiceMock.Verify(c => c.GetAsync<Ingredient>(It.IsAny<string>()), Times.Once());
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
        Ingredient ingredient,
        Mock<ILogger<CachedReadOnlyIngredientRepository>> loggerMock,
        Mock<ICacheService> cacheServiceMock,
        Mock<IOptions<CacheOptions>> cacheOptionsMock,
        Mock<ITenantInfo> tenantMock,
        Mock<IReadOnlyIngredientRepository> readOnlyIngredientRepoMock)
    {
        // Arrange
        cacheOptionsMock.Setup(x => x.Value).Returns(new CacheOptions());
        cacheServiceMock.Setup(c => c.GetAsync<Ingredient>(It.IsAny<string>())).ReturnsAsync((Ingredient)null);
        readOnlyIngredientRepoMock.Setup(x => x.GetUniqueAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>())).ReturnsAsync(ingredient);

        var cachedReadOnlyIngredientRepository = new CachedReadOnlyIngredientRepository(
            loggerMock.Object,
            cacheServiceMock.Object,
            cacheOptionsMock.Object,
            tenantMock.Object,
            readOnlyIngredientRepoMock.Object);        

        // Act
        var entity = await cachedReadOnlyIngredientRepository.GetUniqueAsync(ingredient.Id);

        // Assert
        Assert.Equal(ingredient, entity);
        readOnlyIngredientRepoMock.Verify(x => x.GetUniqueAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()), Times.Once());
        cacheServiceMock.Verify(c => c.GetAsync<Ingredient>(It.IsAny<string>()), Times.Once());
        cacheServiceMock.Verify(c => c.SetAsync(It.IsAny<string>(), ingredient, It.IsAny<TimeSpan>()));
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