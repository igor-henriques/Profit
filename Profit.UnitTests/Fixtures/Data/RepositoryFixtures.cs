namespace Profit.UnitTests.Fixtures.Data;

internal static class RepositoryFixtures
{
    internal static IUnitOfWork GetUnitOfWork(
        Mock<ILogger<UnitOfWork>> loggerMock,
        Mock<IMigratorApplication> migrator,
        string database = null)
    {
        database ??= Guid.NewGuid().ToString();

        var profitOptions = new DbContextOptionsBuilder<ProfitDbContext>()
            .EnableSensitiveDataLogging()
            .UseInMemoryDatabase(databaseName: database)
            .Options;

        var profitContext = new ProfitDbContext(profitOptions);

        var authOptions = new DbContextOptionsBuilder<AuthDbContext>()
            .EnableSensitiveDataLogging()
            .UseInMemoryDatabase(databaseName: "Users")
            .Options;

        var authContext = new AuthDbContext(authOptions);

        var unitOfWork = new UnitOfWork(
            profitContext,
            loggerMock.Object,
            authContext,
            migrator.Object);

        return unitOfWork;
    }
}
