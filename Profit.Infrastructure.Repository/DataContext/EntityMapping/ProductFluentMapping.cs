namespace Profit.Infrastructure.Repository.DataContext.EntityMapping;

public sealed class ProductFluentMapping : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).ValueGeneratedOnAdd();
        builder.Property(p => p.Name).IsRequired().HasMaxLength(Constants.FieldsDefinitions.MaxLengthName);
        builder.Property(p => p.ImageThumbnailUrl).HasMaxLength(Constants.FieldsDefinitions.MaxLengthImageThumbnail);
        builder.Property(p => p.Description).HasMaxLength(Constants.FieldsDefinitions.MaxLengthDescriptions);

        builder.HasOne(p => p.Recipe)
            .WithMany()
            .HasForeignKey(p => p.RecipeId);
    }
}
