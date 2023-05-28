namespace Profit.UnitTests.Tests.Repository;

public sealed class UnitOfWorkTests
{
    [Theory]
    [@AutoData]
    public async Task Commit_ShouldInvokeSaveChangesAsync(
        Mock<ILogger<UnitOfWork>> loggerMock,
        Mock<IRedisCacheService> redisMock,
        IOptions<CacheOptions> configuration,
        Mock<IMigratorApplication> migrator,
        Mock<ITenantInfo> tenantInfo,
        Mock<IReadOnlyUserRepository> userRepo)
    {
        // Arrange
        var unitOfWork = RepositoryFixtures.GetUnitOfWork(
            loggerMock,
            redisMock,
            configuration,
            migrator,
            tenantInfo,
            userRepo,
            "uow-db1");

        // Act
        await unitOfWork.Commit(CancellationToken.None);

        // Act
        var exception = await Record.ExceptionAsync(async () => await unitOfWork.Commit(CancellationToken.None));

        // Assert
        Assert.Null(exception);
    }
}