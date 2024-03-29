﻿namespace Profit.Infrastructure.Repository.DataContext;

public class ProfitDbContext : DbContext
{
    public ProfitDbContext(DbContextOptions<ProfitDbContext> options) : base(options) { }
    public ProfitDbContext() { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new AddressFluentMapping());
        modelBuilder.ApplyConfiguration(new CustomerFluentMapping());
        modelBuilder.ApplyConfiguration(new IngredientFluentMapping());
        modelBuilder.ApplyConfiguration(new IngredientRecipeRelationFluentMapping());
        modelBuilder.ApplyConfiguration(new InvoiceFluentMapping());
        modelBuilder.ApplyConfiguration(new OrderDetailFluentMapping());
        modelBuilder.ApplyConfiguration(new OrderFluentMapping());
        modelBuilder.ApplyConfiguration(new ProductFluentMapping());
        modelBuilder.ApplyConfiguration(new RecipeFluentMapping());
        modelBuilder.HasDefaultSchema("dbo");
    }

    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries())
        {
            if (entry.Entity is IEntity entity)
            {
                switch (entry.State)
                {
                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entity.Delete();
                        break;
                }
            }
        }

        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }

    public DbSet<Ingredient> Ingredients { get; init; }
    public DbSet<IngredientRecipeRelation> IngredientRecipeRelations { get; init; }
    public DbSet<Recipe> Recipes { get; init; }
    public DbSet<Product> Products { get; init; }
    public DbSet<Address> Addresses { get; init; }
    public DbSet<Customer> Customers { get; init; }
    public DbSet<Invoice> Invoices { get; init; }
    public DbSet<OrderDetail> OrderDetails { get; init; }
    public DbSet<Order> Orders { get; init; }
}
