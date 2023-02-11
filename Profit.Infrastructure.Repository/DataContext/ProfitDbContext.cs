namespace Profit.Infrastructure.Repository.DataContext;

public sealed class ProfitDbContext : DbContext
{
    private string _tenantId;
    public ProfitDbContext(DbContextOptions<ProfitDbContext> options) : base(options) { }
    public ProfitDbContext() { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new IngredientFluentMapping(_tenantId));
        modelBuilder.ApplyConfiguration(new IngredientRecipeRelationFluentMapping(_tenantId));
        modelBuilder.ApplyConfiguration(new ProductFluentMapping(_tenantId));
        modelBuilder.ApplyConfiguration(new RecipeFluentMapping(_tenantId));

        modelBuilder.HasDefaultSchema(_tenantId);

        base.OnModelCreating(modelBuilder);
    }

    public void SetTenant(Guid tenantId) => _tenantId = $"db_{CompiledRegex.CheckSpecialCharacterRegex().Replace(tenantId.ToString(), string.Empty)}";

    public DbSet<Ingredient> Ingredients { get; init; }
    public DbSet<IngredientRecipeRelation> IngredientRecipeRelations { get; init; }
    public DbSet<Recipe> Recipes { get; init; }
    public DbSet<Product> Products { get; init; }
}
