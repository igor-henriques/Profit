namespace Profit.UnitTests.Fixtures.Data;

internal sealed class AutoDomainData : AutoDataAttribute
{
    public AutoDomainData() : base(() => new Fixture().Customize(new AutoMoqCustomization())) { }
}
