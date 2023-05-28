﻿namespace Profit.UnitTests.Tests.Repository;

public sealed class UserRepositoryTests
{
    [Theory]
    [@AutoData]
    public async Task Add_Entity_With_Valid_Data_Should_Count_One(
        User user,
        Mock<ILogger<UnitOfWork>> loggerMock,
        Mock<IRedisCacheService> redisMock,
        IOptions<CacheOptions> configuration,
        Mock<IMigratorApplication> migrator,
        Mock<ITenantInfo> tenantInfo,
        Mock<IReadOnlyUserRepository> userRepo)
    {
        // Arrange
        var unitOfWork = RepositoryFixtures.GetUnitOfWork(loggerMock, redisMock, configuration, migrator, tenantInfo, userRepo);

        // Act
        await unitOfWork.UserRepository.Add(user);
        await unitOfWork.Commit();

        // Assert
        (await unitOfWork.UserRepository.CountAsync()).Should().Be(1);
        await unitOfWork.DisposeAsync();
    }

    [Theory]
    [@AutoData]
    public async Task GetUniqueAsync_ShouldReturnCachedEntityWhenAvailable(
        User user,
        Mock<ILogger<UnitOfWork>> loggerMock,
        Mock<IRedisCacheService> redisMock,
        IOptions<CacheOptions> configuration,
        Mock<IMigratorApplication> migrator,
        Mock<ITenantInfo> tenantInfo,
        Mock<IReadOnlyUserRepository> userRepo)
    {
        // Arrange
        redisMock.Setup(c => c.GetAsync<User>(It.IsAny<string>())).ReturnsAsync(user);
        var unitOfWork = RepositoryFixtures.GetUnitOfWork(loggerMock, redisMock, configuration, migrator, tenantInfo, userRepo);

        // Act
        var entity = await unitOfWork.UserRepository.GetUniqueAsync(user.Id);

        // Assert
        Assert.Equal(user, entity);
        redisMock.Verify(c => c.GetAsync<User>(It.IsAny<string>()), Times.Once());
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
        User user,
        Mock<ILogger<UnitOfWork>> loggerMock,
        Mock<IRedisCacheService> redisMock,
        IOptions<CacheOptions> configuration,
        Mock<IMigratorApplication> migrator,
        Mock<ITenantInfo> tenantInfo,
        Mock<IReadOnlyUserRepository> userRepo)
    {
        // Arrange
        redisMock.Setup(c => c.GetAsync<User>(It.IsAny<string>())).ReturnsAsync((User)null);
        var unitOfWork = RepositoryFixtures.GetUnitOfWork(loggerMock, redisMock, configuration, migrator, tenantInfo, userRepo);
        await unitOfWork.UserRepository.Add(user);
        await unitOfWork.Commit();

        // Act
        var entity = await unitOfWork.UserRepository.GetUniqueAsync(user.Id);

        // Assert
        Assert.Equal(user, entity);
        redisMock.Verify(c => c.GetAsync<User>(It.IsAny<string>()), Times.Once());
        await unitOfWork.DisposeAsync();
    }
}