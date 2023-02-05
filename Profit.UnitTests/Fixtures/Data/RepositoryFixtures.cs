namespace Profit.UnitTests.Fixtures.Data;

internal static class RepositoryFixtures
{
    internal static IUnitOfWork GetUnitOfWork(Mock<ILogger<UnitOfWork>> loggerMock, Mock<IRedisCacheService> redisMock)
    {
        // Arrange        
        var options = new DbContextOptionsBuilder<ProfitDbContext>()
            .EnableSensitiveDataLogging()
            .UseInMemoryDatabase(databaseName: "Ingredients")
            .Options;

        var context = new ProfitDbContext(options);
        var unitOfWork = new UnitOfWork(context, loggerMock.Object, redisMock.Object);

        return unitOfWork;
    }
}
