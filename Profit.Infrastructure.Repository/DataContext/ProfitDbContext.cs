namespace Profit.Infrastructure.Repository.DataContext;

public sealed class ProfitDbContext : DbContext
{
    public ProfitDbContext(DbContextOptions<ProfitDbContext> options) : base(options) { }
    public ProfitDbContext() { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        modelBuilder.HasDefaultSchema("dbo");

        base.OnModelCreating(modelBuilder);
    }
    public DbSet<Ingredient> Ingredients { get; init; }
    public DbSet<IngredientRecipeRelation> IngredientRecipeRelations { get; init; }
    public DbSet<Recipe> Recipes { get; init; }
    public DbSet<Product> Products { get; init; }
}
