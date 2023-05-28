namespace Profit.UnitTests.Tests.Domain;

public sealed class ProductTests
{
    [Fact]
    public void Test_Product_Validate_ShouldThrowException_WhenNameIsNull()
    {
        Assert.Throws<ArgumentNullException>(() => new Product(null, 10.0m, "imageUrl", "Description", Guid.NewGuid()));
    }

    [Fact]
    public void Test_Product_Validate_ShouldThrowException_WhenTotalPriceIsNegative()
    {
        Assert.Throws<ArgumentException>(() => new Product("Test", -10.0m, "imageUrl", "Description", Guid.NewGuid()));
    }

    [Fact]
    public void Test_Product_Validate_ShouldThrowException_WhenRecipeIdIsDefault()
    {
        Assert.Throws<ArgumentNullException>(() => new Product("Test", 10.0m, "imageUrl", "Description", Guid.Empty));
    }

    [Fact]
    public void Test_Product_Update_ShouldUpdateProperties()
    {
        var originalProduct = new Product("Test", 10.0m, "imageUrl", "Description", Guid.NewGuid());
        var updatedProduct = new Product("Updated", 20.0m, "updatedUrl", "Updated Description", Guid.NewGuid());

        originalProduct.Update(updatedProduct);

        Assert.Equal(updatedProduct.Name, originalProduct.Name);
        Assert.Equal(updatedProduct.TotalPrice, originalProduct.TotalPrice);
        Assert.Equal(updatedProduct.ImageThumbnailUrl, originalProduct.ImageThumbnailUrl);
        Assert.Equal(updatedProduct.Description, originalProduct.Description);
        Assert.Equal(updatedProduct.RecipeId, originalProduct.RecipeId);
    }

    [Fact]
    public void Test_Product_UpdateName_ShouldThrowException_WhenNameIsNull()
    {
        var product = new Product("Test", 10.0m, "imageUrl", "Description", Guid.NewGuid());
        Assert.Throws<ArgumentNullException>(() => product.UpdateName(null));
    }

    [Fact]
    public void Test_Product_UpdateImageThumbnailUrl_ShouldThrowException_WhenUrlIsNull()
    {
        var product = new Product("Test", 10.0m, "imageUrl", "Description", Guid.NewGuid());
        Assert.Throws<ArgumentNullException>(() => product.UpdateImageThumbnailUrl(null));
    }

    [Fact]
    public void Test_Product_UpdateRecipeId_ShouldThrowException_WhenIdIsDefault()
    {
        var product = new Product("Test", 10.0m, "imageUrl", "Description", Guid.NewGuid());
        Assert.Throws<ArgumentNullException>(() => product.UpdateRecipeId(Guid.Empty));
    }

    [Fact]
    public void Test_Product_UpdateTotalPrice_ShouldThrowException_WhenTotalPriceIsNegative()
    {
        var product = new Product("Test", 10.0m, "imageUrl", "Description", Guid.NewGuid());
        Assert.Throws<ArgumentException>(() => product.UpdateTotalPrice(-10.0m));
    }
}
