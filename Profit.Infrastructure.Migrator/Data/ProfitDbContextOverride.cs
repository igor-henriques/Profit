namespace Profit.Infrastructure.Migrator.Data;

internal sealed class ProfitDbContextOverride : ProfitDbContext, IDbContextSchema
{
    private readonly string _tenantId;
    public string Schema => _tenantId;

    public ProfitDbContextOverride(DbContextOptions<ProfitDbContext> options, Guid tenantId = default) : base(options)
    {
        _tenantId = tenantId == default ? "dbo" : tenantId.FormatTenantToSchema();
    }

    public ProfitDbContextOverride(DbContextOptions<ProfitDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasDefaultSchema(_tenantId);
    }
}
