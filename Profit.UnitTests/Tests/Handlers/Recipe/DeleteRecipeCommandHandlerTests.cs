namespace Profit.UnitTests.Tests.Handlers.Recipe;

public sealed class DeleteRecipeCommandHandlerTests
{
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;
    private readonly DeleteRecipeCommandHandler _handler;
    private readonly Guid _recipeId;

    public DeleteRecipeCommandHandlerTests()
    {
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        _handler = new DeleteRecipeCommandHandler(_unitOfWorkMock.Object);
        _recipeId = Guid.NewGuid();
    }

    [Fact]
    public async Task Should_ThrowException_When_RecipeIdIsNull()
    {
        await Assert.ThrowsAsync<ArgumentNullException>(() => _handler.Handle(new DeleteRecipeCommand { RecipeId = default }, CancellationToken.None));
    }

    [Fact]
    public async Task Should_ThrowException_When_RecipeNotFound()
    {
        _unitOfWorkMock.Setup(u => u.RecipeRepository.GetUniqueAsync(_recipeId, It.IsAny<CancellationToken>()))
            .ReturnsAsync((Profit.Domain.Entities.Recipe)null);

        await Assert.ThrowsAsync<ArgumentNullException>(() => _handler.Handle(new DeleteRecipeCommand { RecipeId = _recipeId }, CancellationToken.None));
    }

    [Fact]
    public async Task Should_ThrowInvalidEntityDeleteException_When_ProductsAreAffected()
    {
        var recipe = new Profit.Domain.Entities.Recipe { Id = _recipeId };
        _unitOfWorkMock.Setup(u => u.RecipeRepository.GetUniqueAsync(_recipeId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(recipe);
        _unitOfWorkMock.Setup(u => u.ProductRepository.GetPaginatedByAsync(x => x.RecipeId == recipe.Id, It.IsAny<CancellationToken>()))
            .ReturnsAsync(new List<Product> { new Product().UpdateName("Product1") });

        await Assert.ThrowsAsync<InvalidEntityDeleteException>(() => _handler.Handle(new DeleteRecipeCommand { RecipeId = _recipeId }, CancellationToken.None));
    }

    [Fact]
    public async Task Should_ThrowEntityNotFoundException_When_RecipeNotFoundAfterDeletion()
    {
        var recipe = new Profit.Domain.Entities.Recipe { Id = _recipeId };
        _unitOfWorkMock.Setup(u => u.RecipeRepository.GetUniqueAsync(_recipeId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(recipe);
        _unitOfWorkMock.Setup(u => u.ProductRepository.GetPaginatedByAsync(x => x.RecipeId == recipe.Id, It.IsAny<CancellationToken>()))
            .ReturnsAsync(new List<Product>());
        _unitOfWorkMock.Setup(u => u.Commit(It.IsAny<CancellationToken>())).ReturnsAsync(0);

        await Assert.ThrowsAsync<EntityNotFoundException>(() => _handler.Handle(new DeleteRecipeCommand { RecipeId = _recipeId }, CancellationToken.None));
    }

    [Fact]
    public async Task Should_DeleteRecipe_When_RecipeExistsAndNoProductsAffected()
    {
        var recipe = new Profit.Domain.Entities.Recipe { Id = _recipeId };
        _unitOfWorkMock.Setup(u => u.RecipeRepository.GetUniqueAsync(_recipeId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(recipe);
        _unitOfWorkMock.Setup(u => u.ProductRepository.GetPaginatedByAsync(x => x.RecipeId == recipe.Id, It.IsAny<CancellationToken>()))
            .ReturnsAsync(new List<Product>());
        _unitOfWorkMock.Setup(u => u.Commit(It.IsAny<CancellationToken>())).ReturnsAsync(1);

        await _handler.Handle(new DeleteRecipeCommand { RecipeId = _recipeId }, CancellationToken.None);

        _unitOfWorkMock.Verify(u => u.RecipeRepository.Delete(recipe), Times.Once);
    }
}
