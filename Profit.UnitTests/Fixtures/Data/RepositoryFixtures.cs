using Microsoft.Extensions.Configuration;

namespace Profit.UnitTests.Fixtures.Data;

internal static class RepositoryFixtures
{
    internal static IUnitOfWork GetUnitOfWork(
        Mock<ILogger<UnitOfWork>> loggerMock, 
        Mock<IRedisCacheService> redisMock,
        Mock<IConfiguration> configuration)
    {
        // Arrange        
        var options = new DbContextOptionsBuilder<ProfitDbContext>()
            .EnableSensitiveDataLogging()
            .UseInMemoryDatabase(databaseName: "Ingredients")
            .Options;

        var context = new ProfitDbContext(options);
        var unitOfWork = new UnitOfWork(context, loggerMock.Object, redisMock.Object, configuration.Object);

        return unitOfWork;
    }
}
