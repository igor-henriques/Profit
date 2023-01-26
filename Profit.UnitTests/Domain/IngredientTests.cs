namespace Profit.UnitTests.Domain;

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
            ingredient.ImageThumbnailUrl);

        var config = new MapperConfiguration(cfg => cfg.AddProfile<IngredientProfile>());
        var mapper = new Mapper(config);

        var ingredientDtoMapped = mapper.Map<IngredientDTO>(ingredient);
        var ingredientMapped = mapper.Map<Ingredient>(ingredientDto);

        ingredientDtoMapped.Should().Be(ingredientDto);
        ingredient.Should().BeEquivalentTo(ingredientMapped, options => options.Excluding(x => x.Guid).Excluding(x => x.UnitPrice));
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
}