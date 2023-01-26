namespace Profit.UnitTests.Repository;

public sealed class IngredientRepository
{
    [Theory]
    [AutoDomainData]
    public async Task Add_Ingredient_With_Valid_Data(Ingredient ingredient, Mock<ILogger<UnitOfWork>> loggerMock)
    {
        // Arrange        
        var options = new DbContextOptionsBuilder<ProfitDbContext>()
            .EnableSensitiveDataLogging()
            .UseInMemoryDatabase(databaseName: "Ingredients")
            .Options;

        using var context = new ProfitDbContext(options);
        var unitOfWork = new UnitOfWork(context, loggerMock.Object);

        // Act
        await unitOfWork.IngredientRepository.Add(ingredient);
        await unitOfWork.SaveAsync();

        // Assert
        Assert.Equal(1, context.Ingredients.Count());
    }
}