using Profit.Infrastructure.Repository.Repositories.ReadOnly;

namespace Profit.UnitTests.Fixtures.Data;

internal static class RepositoryFixtures
{
    internal static IUnitOfWork GetUnitOfWork(
        Mock<ILogger<UnitOfWork>> loggerMock,
        Mock<IRedisCacheService> redisMock,
        IOptions<CacheOptions> configuration,
        Mock<IMigratorApplication> migrator,
        Mock<ITenantInfo> tenantInfo,
        Mock<IReadOnlyUserRepository> readOnlyUserRepoMock,
        string database = "in-memory-db")
    {
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

        var unitOfWork = new UnitOfWork(profitContext, loggerMock.Object, redisMock.Object, configuration, authContext, migrator.Object, tenantInfo.Object, readOnlyUserRepoMock.Object);        

        return unitOfWork;
    }
}
