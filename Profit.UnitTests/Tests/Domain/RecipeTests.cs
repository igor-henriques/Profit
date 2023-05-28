namespace Profit.UnitTests.Tests.Domain;

public sealed class RecipeTests
{
    [Fact]
    public void Test_Recipe_Validate_ShouldThrowException_WhenNameIsNull()
    {
        // Arrange & Act & Assert
        Assert.Throws<ArgumentNullException>(() => new Recipe(null, 10, ""));
    }

    [Fact]
    public void Test_Recipe_Validate_ShouldThrowException_WhenTotalCostIsNegative()
    {
        // Arrange & Act & Assert
        Assert.Throws<ArgumentException>(() => new Recipe("something", -10, ""));
    }

    [Fact]
    public void Test_Recipe_Update_ShouldUpdateProperties()
    {
        // Arrange
        var originalRecipe = new Recipe("Test", 10.0m, "Test Description", new List<IngredientRecipeRelation>());
        var updatedRecipe = new Recipe("Updated", 20.0m, "Updated Description", new List<IngredientRecipeRelation>());

        // Act
        originalRecipe.Update(updatedRecipe);

        // Assert
        Assert.Equal(updatedRecipe.Name, originalRecipe.Name);
        Assert.Equal(updatedRecipe.TotalCost, originalRecipe.TotalCost);
        Assert.Equal(updatedRecipe.Description, originalRecipe.Description);
    }

    [Fact]
    public void Test_Recipe_UpdateName_ShouldThrowException_WhenNameIsNull()
    {
        // Arrange
        var recipe = new Recipe("Test", 10.0m, "Test Description", new List<IngredientRecipeRelation>());

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => recipe.UpdateName(null));
    }

    [Fact]
    public void Test_Recipe_UpdateTotalCost_ShouldThrowException_WhenTotalCostIsNegative()
    {
        // Arrange
        var recipe = new Recipe("Test", 10.0m, "Test Description", new List<IngredientRecipeRelation>());

        // Act & Assert
        Assert.Throws<ArgumentException>(() => recipe.UpdateTotalCost(-10.0m));
    }

    [Fact]
    public void Test_Recipe_SumRelationsCost_Should_Throw_ArgumentNullException_When_Null()
    {
        // Arrange
        var recipe = new Recipe("Test", 10.0m, "Test Description", null);

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => recipe.SumRelationsCost);
    }

    [Fact]
    public void Test_Recipe_SumRelationsCost_Should_Not_Throw_ArgumentNullException_When_Valid()
    {
        // Arrange
        var recipe = new Recipe("Test", 10.0m, "Test Description", new List<IngredientRecipeRelation>());

        // Act
        var exception = Record.Exception(() => recipe.SumRelationsCost);

        // Assert
        Assert.Null(exception);
    }
}
