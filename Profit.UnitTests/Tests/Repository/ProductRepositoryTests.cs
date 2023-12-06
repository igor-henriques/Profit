namespace Profit.UnitTests.Tests.Repository;

public sealed class ProductRepositoryTests
{
    [Theory]
    [@AutoData]
    public async Task AddProduct_WithValidData_ShouldCountOne(
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
        var changeCount = await unitOfWork.Commit();

        // Assert
        changeCount.Should().Be(5);
    }

    [Theory]
    [@AutoData]
    public async Task GetUniqueAsync_ShouldReturnCachedEntity_WhenAvailable(
        Product product,
        Mock<ILogger<CachedReadOnlyProductRepository>> loggerMock,
        Mock<ICacheService> cacheServiceMock,
        Mock<IOptions<CacheOptions>> cacheOptionsMock,
        Mock<ITenantInfo> tenantMock,
        Mock<IReadOnlyProductRepository> readOnlyProductRepoMock)
    {
        // Arrange
        cacheServiceMock.Setup(c => c.GetAsync<Product>(It.IsAny<string>())).ReturnsAsync(product);

        var cachedReadOnlyProductRepository = new CachedReadOnlyProductRepository(
            loggerMock.Object,
            cacheServiceMock.Object,
            cacheOptionsMock.Object,
            tenantMock.Object,
            readOnlyProductRepoMock.Object);

        // Act
        var entity = await cachedReadOnlyProductRepository.GetUniqueAsync(product.Id);

        // Assert
        Assert.Equal(product, entity);
        readOnlyProductRepoMock.Verify(x => x.GetUniqueAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()), Times.Never());
        cacheServiceMock.Verify(c => c.GetAsync<Product>(It.IsAny<string>()), Times.Once());
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
        Product product,
        Mock<ILogger<CachedReadOnlyProductRepository>> loggerMock,
        Mock<ICacheService> cacheServiceMock,
        Mock<IOptions<CacheOptions>> cacheOptionsMock,
        Mock<ITenantInfo> tenantMock,
        Mock<IReadOnlyProductRepository> readOnlyProductRepoMock)
    {
        // Arrange
        cacheOptionsMock.Setup(x => x.Value).Returns(new CacheOptions());
        cacheServiceMock.Setup(c => c.GetAsync<Product>(It.IsAny<string>())).ReturnsAsync((Product)null);
        readOnlyProductRepoMock.Setup(x => x.GetUniqueAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>())).ReturnsAsync(product);

        var cachedReadOnlyProductRepository = new CachedReadOnlyProductRepository(
            loggerMock.Object,
            cacheServiceMock.Object,
            cacheOptionsMock.Object,
            tenantMock.Object,
            readOnlyProductRepoMock.Object);

        // Act
        var entity = await cachedReadOnlyProductRepository.GetUniqueAsync(product.Id);

        // Assert
        Assert.Equal(product, entity);
        readOnlyProductRepoMock.Verify(x => x.GetUniqueAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()), Times.Once());
        cacheServiceMock.Verify(c => c.GetAsync<Product>(It.IsAny<string>()), Times.Once());
        cacheServiceMock.Verify(c => c.SetAsync(It.IsAny<string>(), product, It.IsAny<TimeSpan>()));
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
