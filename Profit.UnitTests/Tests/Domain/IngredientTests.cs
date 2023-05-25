namespace Profit.UnitTests.Tests.Domain;

public sealed class IngredientTests
{
    [Theory(DisplayName = "Mapeamento de ingrediente para DTO deve ser sucesso para entidade válida")]
    [AutoDomainData]
    public void Mapping_Ingredient_To_DTO_Should_Returns_Success_When_Valid_Entity(Ingredient ingredient)
    {
        // Arrange
        var ingredientDto = new IngredientDTO(
            ingredient.Id,
            ingredient.Name,
            ingredient.Price,
            ingredient.Quantity,
            ingredient.ImageThumbnailUrl,
            ingredient.MeasurementUnitType,
            ingredient.Description);

        var config = new MapperConfiguration(cfg => cfg.AddProfile<IngredientProfile>());
        var mapper = new Mapper(config);

        // Act
        var ingredientDtoMapped = mapper.Map<IngredientDTO>(ingredient);
        var ingredientMapped = mapper.Map<Ingredient>(ingredientDto);

        // Assert
        ingredientDtoMapped.Should().Be(ingredientDto);
        ingredient.Should().BeEquivalentTo(ingredientMapped, options => options.Excluding(x => x.UnitPrice));
    }

    [Theory]
    [AutoDomainData]
    public void Update_Ingredient_Name_Should_Throw_Exception_When_Empty(Ingredient ingredient)
    {
        // Arrange
        string invalidEmptyName = "";

        // Act
        Action invalidUpdateExpected = () => ingredient.UpdateName(invalidEmptyName);

        //Assert
        invalidUpdateExpected.Should().ThrowExactly<ArgumentNullException>("Because empty name isn't allowed");
    }

    [Theory]
    [AutoDomainData]
    public void Update_Ingredient_Name_Should_Throw_Exception_When_Null(Ingredient ingredient)
    {
        // Arrange
        string invalidNullName = null;

        // Act
        Action invalidUpdateExpected = () => ingredient.UpdateName(invalidNullName);

        // Assert
        invalidUpdateExpected.Should().ThrowExactly<ArgumentNullException>("Because null name isn't allowed");
    }

    [Theory]
    [AutoDomainData]
    public void Update_Ingredient_Name_Should_Not_Throw_Exception_When_Valid(Ingredient ingredient)
    {
        // Arrange
        string validName = "anything not null or empty";

        // Act
        Action validUpdateExpected = () => ingredient.UpdateName(validName);

        // Assert
        validUpdateExpected.Should().NotThrow("Because it's a valid name");
    }
}