namespace Profit.Infrastructure.Repository.DataContext;

public sealed class AuthDbContext : DbContext
{
    public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options) { }
    public AuthDbContext() { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserFluentMapping());        
        modelBuilder.ApplyConfiguration(new UserClaimFluentMapping());        
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<User> Users { get; init; }
    public DbSet<UserClaim> Claims { get; init; }
}
