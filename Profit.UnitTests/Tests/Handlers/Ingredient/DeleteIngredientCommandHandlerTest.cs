namespace Profit.UnitTests.Tests.Handlers.Ingredient;

public sealed class DeleteIngredientCommandHandlerTest
{
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;
    private readonly DeleteIngredientCommandHandler _handler;
    private readonly Guid _ingredientId;

    public DeleteIngredientCommandHandlerTest()
    {
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        _handler = new DeleteIngredientCommandHandler(_unitOfWorkMock.Object);
        _ingredientId = Guid.NewGuid();
    }

    [Fact]
    public async Task Should_ThrowException_When_IngredientIdIsNull()
    {
        await Assert.ThrowsAsync<ArgumentNullException>(() => _handler.Handle(new DeleteIngredientCommand { IngredientId = default }, CancellationToken.None));
    }

    [Fact]
    public async Task Should_ThrowInvalidEntityDeleteException_When_RecipesAreAffected()
    {
        _unitOfWorkMock.Setup(u => u.RecipeRepository.GetRecipesAndRelationsByIngredientId(_ingredientId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(new List<Profit.Domain.Entities.Recipe> { new Profit.Domain.Entities.Recipe().UpdateName("Recipe1") });

        await Assert.ThrowsAsync<InvalidEntityDeleteException>(() => _handler.Handle(new DeleteIngredientCommand { IngredientId = _ingredientId }, CancellationToken.None));
    }

    [Fact]
    public async Task Should_ThrowEntityNotFoundException_When_IngredientNotFound()
    {
        _unitOfWorkMock.Setup(u => u.RecipeRepository.GetRecipesAndRelationsByIngredientId(_ingredientId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(new List<Profit.Domain.Entities.Recipe>());
        _unitOfWorkMock.Setup(u => u.IngredientRepository.GetUniqueAsync(_ingredientId, It.IsAny<CancellationToken>()))
            .ReturnsAsync((Profit.Domain.Entities.Ingredient)null);
        _unitOfWorkMock.Setup(u => u.Commit(It.IsAny<CancellationToken>())).ReturnsAsync(0);

        await Assert.ThrowsAsync<EntityNotFoundException>(() => _handler.Handle(new DeleteIngredientCommand { IngredientId = _ingredientId }, CancellationToken.None));
    }

    [Fact]
    public async Task Should_DeleteIngredient_When_IngredientExistsAndNoRecipesAffected()
    {
        var ingredient = new Profit.Domain.Entities.Ingredient { Id = _ingredientId };
        _unitOfWorkMock.Setup(u => u.RecipeRepository.GetRecipesAndRelationsByIngredientId(_ingredientId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(new List<Profit.Domain.Entities.Recipe>());
        _unitOfWorkMock.Setup(u => u.IngredientRepository.GetUniqueAsync(_ingredientId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(ingredient);
        _unitOfWorkMock.Setup(u => u.Commit(It.IsAny<CancellationToken>())).ReturnsAsync(1);

        await _handler.Handle(new DeleteIngredientCommand { IngredientId = _ingredientId }, CancellationToken.None);

        _unitOfWorkMock.Verify(u => u.IngredientRepository.Delete(ingredient), Times.Once);
    }
}
