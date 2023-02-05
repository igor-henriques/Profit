namespace Profit.UnitTests.Tests.Repository;

public sealed class IngredientRepositoryTests
{
    [Theory]
    [AutoDomainData]
    public async Task Add_Ingredient_With_Valid_Data_Should_Count_One(
        Ingredient ingredient, 
        Mock<ILogger<UnitOfWork>> loggerMock,
        Mock<IRedisCacheService> redisMock)
    {
        var unitOfWork = RepositoryFixtures.GetUnitOfWork(loggerMock, redisMock);

        await unitOfWork.IngredientRepository.Add(ingredient);
        await unitOfWork.SaveAsync();

        (await unitOfWork.IngredientRepository.CountAsync()).Should().Be(1);
    }
}