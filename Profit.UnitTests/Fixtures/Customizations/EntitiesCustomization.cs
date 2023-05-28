using AutoFixture;

namespace Profit.UnitTests.Fixtures.Customizations;

internal sealed class EntitiesCustomization : ICustomization
{
    public void Customize(IFixture fixture)
    {
        fixture.Customize<Ingredient>(c => c
            .Without(i => i.IngredientRecipeRelations)
            .Do(i => i.UpdateName(fixture.Create<string>()))
            .Do(i => i.UpdatePrice(fixture.Create<decimal>()))
            .Do(i => i.UpdateMeasurementUnit(fixture.Create<EMeasurementUnit>()))
            .Do(i => i.UpdateQuantity(fixture.Create<decimal>()))
            .Do(i => i.UpdateImageThumbnailUrl(fixture.Create<string>()))
            .Do(i => i.UpdateDescription(fixture.Create<string>())));

        fixture.Customize<Recipe>(c => c
            .Do(r => r.UpdateName(fixture.Create<string>()))
            .Do(r => r.UpdateTotalCost(fixture.Create<decimal>()))
            .Do(r => r.UpdateDescription(fixture.Create<string>())));

        fixture.Customize<Product>(c => c
             .Do(p => p.UpdateName(fixture.Create<string>()))
             .Do(p => p.UpdateTotalPrice(fixture.Create<decimal>()))
             .Do(p => p.UpdateImageThumbnailUrl(fixture.Create<string>()))
             .Do(p => p.UpdateDescription(fixture.Create<string>())));

        fixture.Customize<User>(c => c
             .Do(p => p.UpdateEmail(fixture.Create<string>()))
             .Do(p => p.UpdateUsername(fixture.Create<string>()))
             .Do(p => p.UpdateHashedPassword(fixture.Create<string>())));

        fixture.Customize<IngredientRecipeRelation>(c => c
             .Without(p => p.Ingredient)
             .Without(p => p.Recipe)
             .Do(p => p.UpdateRecipeId(fixture.Create<Guid>()))
             .Do(p => p.UpdateIngredientId(fixture.Create<Guid>()))
             .Do(p => p.UpdateIngredientCount(fixture.Create<decimal>()))
             .Do(p => p.UpdateRelationCost(fixture.Create<decimal>())));
    }
}
