namespace Profit.UnitTests.Tests.Repository;

public sealed class UserRepositoryTests
{
    [Theory]
    [@AutoData]
    public async Task Add_Entity_With_Valid_Data_Should_Count_One(
        User user,
        Mock<ILogger<UnitOfWork>> loggerMock,
        Mock<IMigratorApplication> migrator)
    {
        // Arrange
        var unitOfWork = RepositoryFixtures.GetUnitOfWork(
            loggerMock,
            migrator);

        // Act
        await unitOfWork.UserRepository.Add(user);
        var changeCount = await unitOfWork.Commit();

        // Assert
        changeCount.Should().Be(2);
    }

    [Theory]
    [@AutoData]
    public async Task GetUniqueAsync_ShouldReturnCachedEntity_WhenAvailable(
       User user,
       Mock<ILogger<CachedReadOnlyUserRepository>> loggerMock,
       Mock<ICacheService> cacheServiceMock,
       Mock<IOptions<CacheOptions>> cacheOptionsMock,
       Mock<IReadOnlyUserRepository> readOnlyUserRepoMock)
    {
        // Arrange
        cacheServiceMock.Setup(c => c.GetAsync<User>(It.IsAny<string>())).ReturnsAsync(user);

        var cachedReadOnlyUserRepository = new CachedReadOnlyUserRepository(
            loggerMock.Object,
            cacheServiceMock.Object,
            cacheOptionsMock.Object,
            readOnlyUserRepoMock.Object);

        // Act
        var entity = await cachedReadOnlyUserRepository.GetUniqueAsync(user.Id);

        // Assert
        Assert.Equal(user, entity);
        readOnlyUserRepoMock.Verify(x => x.GetUniqueAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()), Times.Never());
        cacheServiceMock.Verify(c => c.GetAsync<User>(It.IsAny<string>()), Times.Once());
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
        User user,
        Mock<ILogger<CachedReadOnlyUserRepository>> loggerMock,
        Mock<ICacheService> cacheServiceMock,
        Mock<IOptions<CacheOptions>> cacheOptionsMock,
        Mock<IReadOnlyUserRepository> readOnlyUserRepoMock)
    {
        // Arrange
        cacheOptionsMock.Setup(x => x.Value).Returns(new CacheOptions());
        cacheServiceMock.Setup(c => c.GetAsync<User>(It.IsAny<string>())).ReturnsAsync((User)null);
        readOnlyUserRepoMock.Setup(x => x.GetUniqueAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>())).ReturnsAsync(user);

        var cachedReadOnlyUserRepository = new CachedReadOnlyUserRepository(
            loggerMock.Object,
            cacheServiceMock.Object,
            cacheOptionsMock.Object,
            readOnlyUserRepoMock.Object);

        // Act
        var entity = await cachedReadOnlyUserRepository.GetUniqueAsync(user.Id);

        // Assert
        Assert.Equal(user, entity);
        readOnlyUserRepoMock.Verify(x => x.GetUniqueAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()), Times.Once());
        cacheServiceMock.Verify(c => c.GetAsync<User>(It.IsAny<string>()), Times.Once());
        cacheServiceMock.Verify(c => c.SetAsync(It.IsAny<string>(), user, It.IsAny<TimeSpan>()));
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
