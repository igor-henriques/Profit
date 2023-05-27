namespace Profit.Infrastructure.Migrator.Data;

public sealed class ProfitDbContextOverride : ProfitDbContext, IDbContextSchema
{
    private readonly string _tenantId;
    public string Schema => _tenantId;

    public ProfitDbContextOverride(DbContextOptions<ProfitDbContext> options, Guid tenantId) : base(options)
    {
        _tenantId = tenantId.FormatTenantToSchema();
    }

    public ProfitDbContextOverride(DbContextOptions<ProfitDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(IngredientFluentMapping).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(IngredientRecipeRelationFluentMapping).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductFluentMapping).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(RecipeFluentMapping).Assembly);
        modelBuilder.HasDefaultSchema(_tenantId);
    }
}
