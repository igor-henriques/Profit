namespace Profit.UnitTests.Tests.Repository;

public sealed class ProductRepositoryTests
{
    [Theory]
    [@AutoData]
    public async Task Add_Entity_With_Valid_Data_Should_Count_One(
        Product product,
        Mock<ILogger<UnitOfWork>> loggerMock,
        Mock<IMigratorApplication> migrator)
    {
        // Arrange
        var unitOfWork = RepositoryFixtures.GetUnitOfWork(
            loggerMock,
            migrator);

        // Act
        await unitOfWork.ProductRepository.Add(product);
        await unitOfWork.Commit();

        // Assert
        //(await unitOfWork.ProductRepository.CountAsync()).Should().Be(1);
        await unitOfWork.DisposeAsync();
    }

    [Theory]
    [@AutoData]
    public async Task GetUniqueAsync_ShouldReturnCachedEntityWhenAvailable(
        Product product,
        Mock<ILogger<UnitOfWork>> loggerMock,
        Mock<ICacheService> redisMock,
        Mock<IMigratorApplication> migrator)
    {
        // Arrange
        redisMock.Setup(c => c.GetAsync<Product>(It.IsAny<string>())).ReturnsAsync(product);
        var unitOfWork = RepositoryFixtures.GetUnitOfWork(
            loggerMock,
            migrator);

        // Act
        var entity = await unitOfWork.ProductRepository.GetUniqueAsync(product.Id);

        // Assert
        Assert.Equal(product, entity);
        redisMock.Verify(c => c.GetAsync<Product>(It.IsAny<string>()), Times.Once());
        loggerMock.Verify(
            x => x.Log(
                It.Is<LogLevel>(x => x == LogLevel.Information),
                It.IsAny<EventId>(),
                It.IsAny<It.IsAnyType>(),
                It.IsAny<Exception>(),
                It.IsAny<Func<It.IsAnyType, Exception, string>>()),
            Times.Once);
        await unitOfWork.DisposeAsync();
    }

    [Theory]
    [@AutoData]
    public async Task GetUniqueAsync_ShouldReturnRepoEntityWhenCacheIsEmpty(
        Product product,
        Mock<ILogger<UnitOfWork>> loggerMock,
        Mock<ICacheService> redisMock,
        Mock<IMigratorApplication> migrator)
    {
        // Arrange
        redisMock.Setup(c => c.GetAsync<Product>(It.IsAny<string>())).ReturnsAsync((Product)null);
        var unitOfWork = RepositoryFixtures.GetUnitOfWork(
            loggerMock,
            migrator);

        await unitOfWork.ProductRepository.Add(product);

        // Act
        var entity = await unitOfWork.ProductRepository.GetUniqueAsync(product.Id);

        // Assert
        Assert.Equal(product, entity);
        redisMock.Verify(c => c.GetAsync<Product>(It.IsAny<string>()), Times.Once());
        await unitOfWork.DisposeAsync();
    }
}
