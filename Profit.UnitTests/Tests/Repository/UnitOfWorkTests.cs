namespace Profit.UnitTests.Tests.Repository;

public sealed class UnitOfWorkTests
{
    [Theory]
    [@AutoData]
    public async Task Commit_ShouldInvokeSaveChangesAsync(
        Mock<ILogger<UnitOfWork>> loggerMock,
        Mock<IMigratorApplication> migrator)
    {
        // Arrange
        var unitOfWork = RepositoryFixtures.GetUnitOfWork(
            loggerMock,
            migrator);

        // Act
        await unitOfWork.Commit(CancellationToken.None);

        // Act
        var exception = await Record.ExceptionAsync(async () => await unitOfWork.Commit(CancellationToken.None));

        // Assert
        Assert.Null(exception);
    }
}