namespace Profit.UnitTests.Tests.Repository;

public sealed class IngredientRepositoryTests
{
    [Theory]
    [AutoDomainData]
    public async Task Add_Ingredient_With_Valid_Data_Should_Count_One(
        Ingredient ingredient,
        Mock<ILogger<UnitOfWork>> loggerMock,
        Mock<IRedisCacheService> redisMock,
        Mock<IConfiguration> configuration,
        Mock<IMigratorApplication> migrator,
        Mock<ITenantInfo> tenantInfo)
    {
        // Arrange
        var unitOfWork = RepositoryFixtures.GetUnitOfWork(loggerMock, redisMock, configuration, migrator, tenantInfo);

        // Act
        await unitOfWork.IngredientRepository.Add(ingredient);
        await unitOfWork.Commit();

        // Assert
        (await unitOfWork.IngredientRepository.CountAsync()).Should().Be(1);
    }

    [Theory]
    [AutoDomainData]
    public async Task GetUniqueAsync_ShouldReturnCachedEntityWhenAvailable(
        Ingredient ingredient,
        Mock<ILogger<UnitOfWork>> loggerMock,
        Mock<IRedisCacheService> redisMock,
        Mock<IConfiguration> configuration,
        Mock<IMigratorApplication> migrator,
        Mock<ITenantInfo> tenantInfo)
    {
        // Arrange
        redisMock.Setup(c => c.GetAsync<Ingredient>(It.IsAny<string>())).ReturnsAsync(ingredient);
        var unitOfWork = RepositoryFixtures.GetUnitOfWork(loggerMock, redisMock, configuration, migrator, tenantInfo);

        // Act
        var entity = await unitOfWork.IngredientRepository.GetUniqueAsync(ingredient.Id);

        // Assert
        Assert.Equal(ingredient, entity);
        redisMock.Verify(c => c.GetAsync<Ingredient>(It.IsAny<string>()), Times.Once());
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
    [AutoDomainData]
    public async Task GetUniqueAsync_ShouldReturnRepoEntityWhenCacheIsEmpty(
        Ingredient ingredient,
        Mock<ILogger<UnitOfWork>> loggerMock,
        Mock<IRedisCacheService> redisMock,
        Mock<IConfiguration> configuration,
        Mock<IMigratorApplication> migrator,
        Mock<ITenantInfo> tenantInfo)
    {
        // Arrange
        redisMock.Setup(c => c.GetAsync<Ingredient>(It.IsAny<string>())).ReturnsAsync((Ingredient)null);
        var unitOfWork = RepositoryFixtures.GetUnitOfWork(loggerMock, redisMock, configuration, migrator, tenantInfo);
        await unitOfWork.IngredientRepository.Add(ingredient);

        // Act
        var entity = await unitOfWork.IngredientRepository.GetUniqueAsync(ingredient.Id);

        // Assert
        Assert.Equal(ingredient, entity);
        redisMock.Verify(c => c.GetAsync<Ingredient>(It.IsAny<string>()), Times.Once());
    }
}