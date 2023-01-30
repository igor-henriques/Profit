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
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Ingredient> Ingredients { get; init; }    
}
