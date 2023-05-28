namespace Profit.UnitTests.Fixtures.Data;

internal static class RepositoryFixtures
{
    internal static IUnitOfWork GetUnitOfWork(
        Mock<ILogger<UnitOfWork>> loggerMock,
        Mock<IRedisCacheService> redisMock,
        Mock<IConfiguration> configuration,
        Mock<IMigratorApplication> migrator,
        Mock<ITenantInfo> tenantInfo)
    {
        var profitOptions = new DbContextOptionsBuilder<ProfitDbContext>()
            .EnableSensitiveDataLogging()
            .UseInMemoryDatabase(databaseName: "Ingredients")
            .Options;

        var profitContext = new ProfitDbContext(profitOptions);

        var authOptions = new DbContextOptionsBuilder<AuthDbContext>()
            .EnableSensitiveDataLogging()
            .UseInMemoryDatabase(databaseName: "Users")
            .Options;

        var authContext = new AuthDbContext(authOptions);

        var unitOfWork = new UnitOfWork(profitContext, loggerMock.Object, redisMock.Object, configuration.Object, authContext, migrator.Object, tenantInfo.Object);

        return unitOfWork;
    }
}
