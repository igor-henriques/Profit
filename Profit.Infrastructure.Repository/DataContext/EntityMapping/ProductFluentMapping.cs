namespace Profit.Infrastructure.Repository.DataContext.EntityMapping;

public sealed class ProductFluentMapping : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).ValueGeneratedOnAdd();
        builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
        builder.Property(p => p.ImageThumbnailUrl).IsRequired().HasMaxLength(500);
        builder.Property(p => p.Description).HasMaxLength(200);

        builder.HasOne(p => p.Recipe)
            .WithMany()
            .HasForeignKey(p => p.RecipeId);
    }
}
