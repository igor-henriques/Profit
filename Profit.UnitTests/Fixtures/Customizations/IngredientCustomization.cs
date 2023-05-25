namespace Profit.UnitTests.Fixtures.Customizations;

internal sealed class IngredientCustomization : ICustomization
{
    public void Customize(IFixture fixture)
    {
        fixture.Customize<Ingredient>(c => c
            .Without(i => i.IngredientRecipeRelations)
            .Do(i => i.UpdateName(fixture.Create<string>()))
            .Do(i => i.UpdatePrice(fixture.Create<decimal>()))
            .Do(i => i.UpdateMeasurementUnitType(fixture.Create<EMeasurementUnit>()))
            .Do(i => i.UpdateQuantity(fixture.Create<decimal>()))
            .Do(i => i.UpdateImageThumbnailUrl(fixture.Create<string>()))
            .Do(i => i.UpdateDescription(fixture.Create<string>())));
    }
}
