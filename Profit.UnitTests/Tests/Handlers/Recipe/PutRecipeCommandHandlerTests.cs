namespace Profit.UnitTests.Tests.Handlers.Recipe;

public sealed class PutRecipeCommandHandlerTests
{
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;
    private readonly Mock<IMapper> _mapperMock;
    private readonly PutRecipeCommandHandler _handler;
    private readonly Guid _recipeId;

    public PutRecipeCommandHandlerTests()
    {
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        _mapperMock = new Mock<IMapper>();
        _handler = new PutRecipeCommandHandler(_unitOfWorkMock.Object, _mapperMock.Object);
        _recipeId = Guid.NewGuid();
    }

    [Fact]
    public async Task Should_ThrowEntityNotFoundException_When_No_Changes()
    {
        var recipe = new Profit.Domain.Entities.Recipe()
        {
            Id = _recipeId,
            IngredientRecipeRelations = new List<IngredientRecipeRelation>()
        }.UpdateName("anything").UpdateDescription("whatever");

        var recipeCommand = new PutRecipeCommand()
        {
            Id = recipe.Id,
            Name = "anything",
            Description = "whatever",
            IngredientRecipeRelations = new List<IngredientRecipeRelationDto>()
        };

        _mapperMock.Setup(m => m.Map<Profit.Domain.Entities.Recipe>(It.IsAny<PutRecipeCommand>()))
            .Returns(recipe);
        _unitOfWorkMock.Setup(u => u.RecipeRepository.GetUniqueAsync(_recipeId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(recipe);

        _unitOfWorkMock.Setup(u => u.Commit(It.IsAny<CancellationToken>())).ReturnsAsync(0);

        await Assert.ThrowsAsync<EntityNotFoundException>(() => _handler.Handle(recipeCommand, CancellationToken.None));
    }

    [Fact]
    public async Task Should_ThrowArgumentNullException_When_RecipeNotFound()
    {
        var recipe = new Profit.Domain.Entities.Recipe()
        {
            Id = _recipeId,
            IngredientRecipeRelations = new List<IngredientRecipeRelation>()
        }.UpdateName("anything").UpdateDescription("whatever");

        var recipeCommand = new PutRecipeCommand()
        {
            Id = recipe.Id,
            Name = "anything",
            Description = "whatever",
            IngredientRecipeRelations = new List<IngredientRecipeRelationDto>()
        };

        _mapperMock.Setup(m => m.Map<Profit.Domain.Entities.Recipe>(It.IsAny<PutRecipeCommand>()))
            .Returns(recipe);

        _unitOfWorkMock.Setup(u => u.RecipeRepository.GetUniqueAsync(_recipeId, It.IsAny<CancellationToken>()))
            .ReturnsAsync((Profit.Domain.Entities.Recipe)null);

        await Assert.ThrowsAsync<ArgumentNullException>(() => _handler.Handle(recipeCommand, CancellationToken.None));
    }

    [Fact]
    public async Task Should_UpdateRecipe_When_RecipeExists()
    {
        var recipe = new Profit.Domain.Entities.Recipe()
        {
            Id = _recipeId,
            IngredientRecipeRelations = new List<IngredientRecipeRelation>()
        }.UpdateName("anything").UpdateDescription("whatever");

        var recipeCommand = new PutRecipeCommand()
        {
            Id = recipe.Id,
            Name = "anything",
            Description = "whatever",
            IngredientRecipeRelations = new List<IngredientRecipeRelationDto>()
        };

        _mapperMock.Setup(m => m.Map<Profit.Domain.Entities.Recipe>(It.IsAny<PutRecipeCommand>()))
            .Returns(recipe);
        _unitOfWorkMock.Setup(u => u.RecipeRepository.GetUniqueAsync(_recipeId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(recipe);
        _unitOfWorkMock.Setup(u => u.Commit(It.IsAny<CancellationToken>())).ReturnsAsync(1);

        await _handler.Handle(recipeCommand, CancellationToken.None);

        _unitOfWorkMock.Verify(u => u.RecipeRepository.GetUniqueAsync(_recipeId, It.IsAny<CancellationToken>()), Times.Once);
        _unitOfWorkMock.Verify(u => u.Commit(It.IsAny<CancellationToken>()), Times.Once);
    }
}
