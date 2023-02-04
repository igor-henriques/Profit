namespace Profit.UnitTests.Tests.Domain;

public sealed class IngredientTests
{
    [Theory(DisplayName = "Mapeamento de ingrediente para DTO deve ser sucesso para entidade válida")]
    [AutoDomainData]
    public void Mapping_Ingredient_To_DTO_Should_Returns_Success_When_Valid_Entity(Ingredient ingredient)
    {
        var ingredientDto = new IngredientDTO(
            ingredient.Name,
            ingredient.Price,
            ingredient.Quantity,
            ingredient.ImageThumbnailUrl,
            ingredient.MeasurementUnitType);

        var config = new MapperConfiguration(cfg => cfg.AddProfile<IngredientProfile>());
        var mapper = new Mapper(config);

        var ingredientDtoMapped = mapper.Map<IngredientDTO>(ingredient);
        var ingredientMapped = mapper.Map<Ingredient>(ingredientDto);

        ingredientDtoMapped.Should().Be(ingredientDto);
        ingredient.Should().BeEquivalentTo(ingredientMapped, options => options.Excluding(x => x.UnitPrice));
    }

    [Theory]
    [AutoDomainData]
    public void Update_Ingredient_Name_Should_Throw_Exception_When_Invalid(Ingredient ingredient)
    {
        string validName = "anything not null or empty";
        string invalidEmptyName = "";
        string invalidNullName = null;

        var validUpdateExpected = () => ingredient.UpdateName(validName);
        var invalidUpdateExpected = () => ingredient.UpdateName(invalidEmptyName);
        var invalidUpdateExpected2 = () => ingredient.UpdateName(invalidNullName);

        invalidUpdateExpected.Should().ThrowExactly<ArgumentException>("Because empty name isn't allowed");
        invalidUpdateExpected2.Should().ThrowExactly<ArgumentException>("Because null name isn't allowed");
        validUpdateExpected.Should().NotThrow("Because it's a valid name");
    }

    [Fact]
    public void Create_Invalid_Ingredient_Should_Throw_Exception()
    {
        //var invalidIngredientData = DomainFixtures.GetInvalidIngredientData;
        //var validIngredientData = DomainFixtures.GetValidIngredientData;

        //var validCreateExpected = () => new Ingredient(validIngredientData.Item1, validIngredientData.Item3, validIngredientData.Item2, validIngredientData.Item4, "");
        //var invalidNameCreateExpected = () => new Ingredient(invalidIngredientData.Item1, validIngredientData.Item2, validIngredientData.Item3, validIngredientData.Item4);
        //var invalidPriceCreateExpected = () => new Ingredient(validIngredientData.Item1, invalidIngredientData.Item2, validIngredientData.Item3, validIngredientData.Item4);
        //var invalidQuantityCreateExpected = () => new Ingredient(validIngredientData.Item1, validIngredientData.Item2, invalidIngredientData.Item3, validIngredientData.Item4);
        //var invalidThumbnailCreateExpected = () => new Ingredient(validIngredientData.Item1, validIngredientData.Item2, validIngredientData.Item3, invalidIngredientData.Item4);

        //invalidNameCreateExpected.Should().ThrowExactly<ArgumentException>("Because empty name isn't allowed");
        //invalidPriceCreateExpected.Should().ThrowExactly<ArgumentException>("Because negative price isn't allowed");
        //invalidQuantityCreateExpected.Should().ThrowExactly<ArgumentException>("Because negative quantity isn't allowed");
        //invalidThumbnailCreateExpected.Should().ThrowExactly<ArgumentException>("Because empty image thumbnail url isn't allowed");
        //validCreateExpected.Should().NotThrow("Because it's a valid ingredient");
    }
}