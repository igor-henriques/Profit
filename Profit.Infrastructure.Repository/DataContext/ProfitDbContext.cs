namespace Profit.Infrastructure.Repository.DataContext;

public sealed class ProfitDbContext : DbContext
{
    private string _tenantId;
    public ProfitDbContext(DbContextOptions<ProfitDbContext> options) : base(options) {}
    public ProfitDbContext() { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new IngredientFluentMapping());
        modelBuilder.ApplyConfiguration(new IngredientRecipeRelationFluentMapping());
        modelBuilder.ApplyConfiguration(new ProductFluentMapping());
        modelBuilder.ApplyConfiguration(new RecipeFluentMapping());

        modelBuilder.HasDefaultSchema(_tenantId);
        
        base.OnModelCreating(modelBuilder);
    }
    
    public void SetTenant(Guid tenantId) => _tenantId = tenantId.ToString();

    public DbSet<Ingredient> Ingredients { get; init; }    
    public DbSet<IngredientRecipeRelation> IngredientRecipeRelations { get; init; }
    public DbSet<Recipe> Recipes { get; init; }
    public DbSet<Product> Products { get; init; }
}
