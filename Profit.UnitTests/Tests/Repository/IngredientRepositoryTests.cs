using Microsoft.Extensions.Configuration;

namespace Profit.UnitTests.Tests.Repository;

public sealed class IngredientRepositoryTests
{
    [Theory]
    [AutoDomainData]
    public async Task Add_Ingredient_With_Valid_Data_Should_Count_One(
        Ingredient ingredient,
        Mock<ILogger<UnitOfWork>> loggerMock,
        Mock<IRedisCacheService> redisMock,
        Mock<IConfiguration> configuration)
    {
        var unitOfWork = RepositoryFixtures.GetUnitOfWork(loggerMock, redisMock, configuration);

        await unitOfWork.IngredientRepository.Add(ingredient);
        await unitOfWork.Commit();

        (await unitOfWork.IngredientRepository.CountAsync()).Should().Be(1);
    }
}