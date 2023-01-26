using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using Profit.Infrastructure.Repository.DataContext;
using Profit.Infrastructure.Repository.Repositories;

namespace Profit.UnitTests.Repository;

public sealed class IngredientRepository
{
    [Theory]
    [AutoDomainData]
    public async Task Add_Ingredient_With_Valid_Data(Ingredient ingredient, Mock<ILogger<UnitOfWork>> loggerMock)
    {
        // Arrange        
        var options = new DbContextOptionsBuilder<ProfitDbContext>()
            .UseInMemoryDatabase(databaseName: "Ingredients")
            .Options;
        
        using var context = new ProfitDbContext(options);        
        var unitOfWork = new UnitOfWork(context, loggerMock.Object);

        // Act
        unitOfWork.IngredientRepository.Add(ingredient);
        await unitOfWork.Save();

        // Assert
        Assert.Equal(1, context.Ingredients.Count());
    }
}
