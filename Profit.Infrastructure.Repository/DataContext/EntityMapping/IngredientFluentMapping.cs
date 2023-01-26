namespace Profit.Infrastructure.Repository.DataContext.EntityMapping;

public sealed class IngredientFluentMapping : IEntityTypeConfiguration<Ingredient>
{
    public void Configure(EntityTypeBuilder<Ingredient> builder)
    {
        builder.HasKey(i => i.Guid);
        builder.Property(i => i.Guid).ValueGeneratedOnAdd();
        builder.Property(i => i.Name).IsRequired().HasMaxLength(100);
        builder.Property(i => i.Price).IsRequired().HasPrecision(18, 2);
        builder.Property(i => i.Quantity).IsRequired().HasPrecision(18, 2);
        builder.Property(i => i.TotalPrice).IsRequired().HasPrecision(18, 2);
        builder.Property(i => i.ImageThumbnailUrl).IsRequired().HasMaxLength(500);
    }
}
