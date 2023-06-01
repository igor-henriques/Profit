namespace Profit.UnitTests.Fixtures.Data;

internal sealed class AutoData : AutoDataAttribute
{
    public AutoData() : base(() =>
    {
        var fixture = new Fixture().Customize(new AutoMoqCustomization());

        fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
            .ForEach(b => fixture.Behaviors.Remove(b));
        fixture.Behaviors.Add(new OmitOnRecursionBehavior());

        fixture.Customize(new EntitiesCustomization());

        fixture.Customize<IOptions<CacheOptions>>(c =>
            c.FromFactory(() => Options.Create(new CacheOptions { SecondsDuration = 60 })));

        fixture.Customize<ProfitDbContext>(c =>
            c.FromFactory(() =>
            {
                var profitOptions = new DbContextOptionsBuilder<ProfitDbContext>()
                   .EnableSensitiveDataLogging()
                   .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                   .Options;

                var profitContext = new ProfitDbContext(profitOptions);
                return profitContext;
            }));

        fixture.Customize<AuthDbContext>(c =>
            c.FromFactory(() =>
            {
                var profitOptions = new DbContextOptionsBuilder<AuthDbContext>()
                   .EnableSensitiveDataLogging()
                   .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                   .Options;

                var profitContext = new AuthDbContext(profitOptions);
                return profitContext;
            }));

        return fixture;
    })
    { }
}
