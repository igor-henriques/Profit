namespace Profit.UnitTests.Tests.Handlers.Ingredient;

public sealed class PutIngredientCommandHandlerTests
{
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;
    private readonly Mock<IMapper> _mapperMock;
    private readonly PutIngredientCommandHandler _handler;

    public PutIngredientCommandHandlerTests()
    {
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        _mapperMock = new Mock<IMapper>();

        _handler = new PutIngredientCommandHandler(_unitOfWorkMock.Object, _mapperMock.Object);
    }

    [Theory]
    [AutoDomainData]
    public async Task Handle_ShouldUpdateIngredientAndCommit_WhenCalledWithValidRequest(
        PutIngredientCommand command,
        Profit.Domain.Entities.Ingredient ingredient)
    {
        // Arrange           
        _mapperMock.Setup(m => m.Map<Profit.Domain.Entities.Ingredient>(command)).Returns(ingredient);

        var ingredientRecipeRelations = new List<Recipe>() { /* Adicione suas instâncias aqui */ };

        _unitOfWorkMock.Setup(u => u.IngredientRepository.Update(It.IsAny<Profit.Domain.Entities.Ingredient>()));

        _unitOfWorkMock.Setup(u => u.RecipeRepository.GetRecipesAndRelationsByIngredientId(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(ingredientRecipeRelations);

        var products = new List<Product>() { /* Adicione suas instâncias aqui */ };

        _unitOfWorkMock.Setup(u => u.ProductRepository.GetProductsByRecipeId(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(products);

        _unitOfWorkMock.Setup(u => u.Commit(It.IsAny<CancellationToken>())).ReturnsAsync(1);

        // Act
        await _handler.Handle(command, CancellationToken.None);

        // Assert
        _unitOfWorkMock.Verify(u => u.IngredientRepository.Update(ingredient), Times.Once);
        _unitOfWorkMock.Verify(u => u.Commit(It.IsAny<CancellationToken>()), Times.Once);
    }
}
