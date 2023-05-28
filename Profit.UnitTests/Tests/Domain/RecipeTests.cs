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
        var originalRecipe = new Recipe("Test", 10.0m, "Test Description", new List<IngredientRecipeRelation>());
        var updatedRecipe = new Recipe("Updated", 20.0m, "Updated Description", new List<IngredientRecipeRelation>());

        originalRecipe.Update(updatedRecipe);

        Assert.Equal(updatedRecipe.Name, originalRecipe.Name);
        Assert.Equal(updatedRecipe.TotalCost, originalRecipe.TotalCost);
        Assert.Equal(updatedRecipe.Description, originalRecipe.Description);
    }

    [Fact]
    public void Test_Recipe_UpdateName_ShouldThrowException_WhenNameIsNull()
    {
        var recipe = new Recipe("Test", 10.0m, "Test Description", new List<IngredientRecipeRelation>());
        Assert.Throws<ArgumentNullException>(() => recipe.UpdateName(null));
    }

    [Fact]
    public void Test_Recipe_UpdateTotalCost_ShouldThrowException_WhenTotalCostIsNegative()
    {
        var recipe = new Recipe("Test", 10.0m, "Test Description", new List<IngredientRecipeRelation>());
        Assert.Throws<ArgumentException>(() => recipe.UpdateTotalCost(-10.0m));
    }
}
