namespace Profit.Infrastructure.Migrator.Data;

public sealed class ProfitDbContextOverrideFactory : IDesignTimeDbContextFactory<ProfitDbContextOverride>
{
    public ProfitDbContextOverride CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ProfitDbContext>();
        optionsBuilder.UseSqlServer("Your Connection String");

        return new ProfitDbContextOverride(optionsBuilder.Options);
    }
}
