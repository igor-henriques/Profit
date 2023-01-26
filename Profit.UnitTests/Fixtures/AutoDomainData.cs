using AutoFixture.Xunit2;

namespace Profit.UnitTests.Fixtures;

public sealed class AutoDomainData : AutoDataAttribute
{
    public AutoDomainData() : base(() => new Fixture().Customize(new AutoMoqCustomization())) { }
}
