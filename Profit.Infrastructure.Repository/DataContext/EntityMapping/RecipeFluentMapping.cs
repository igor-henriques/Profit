namespace Profit.Infrastructure.Repository.DataContext.EntityMapping;

public sealed class RecipeFluentMapping : IEntityTypeConfiguration<Recipe>
{
    public void Configure(EntityTypeBuilder<Recipe> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
        builder.Property(x => x.TotalCost).IsRequired().HasPrecision(18, 2);
        builder.Property(x => x.Description).HasMaxLength(200);
    }
}
