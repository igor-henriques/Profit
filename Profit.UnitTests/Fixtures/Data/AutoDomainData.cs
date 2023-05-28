namespace Profit.UnitTests.Fixtures.Data;

internal sealed class AutoDomainData : AutoDataAttribute
{
    public AutoDomainData() : base(() =>
    {
        var fixture = new Fixture().Customize(new AutoMoqCustomization());

        fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
            .ForEach(b => fixture.Behaviors.Remove(b));
        fixture.Behaviors.Add(new OmitOnRecursionBehavior());

        fixture.Customize(new EntitiesCustomization());

        return fixture;
    })
    { }
}
