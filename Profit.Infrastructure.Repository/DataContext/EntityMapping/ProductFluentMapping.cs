﻿namespace Profit.Infrastructure.Repository.DataContext.EntityMapping;

public sealed class ProductFluentMapping : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasQueryFilter(x => !x.IsDeleted);
        builder.HasKey(p => p.Id);
        builder.ToTable(Constants.TableNames.Product);
        builder.Property(p => p.Id).ValueGeneratedOnAdd();
        builder.Property(p => p.TotalPrice).IsRequired().HasPrecision(18, 2);
        builder.Property(p => p.Name).IsRequired().HasMaxLength(Constants.FieldsDefinitions.MaxLengthName);
        builder.Property(p => p.ImageThumbnailUrl).HasMaxLength(Constants.FieldsDefinitions.MaxLengthImageThumbnail);
        builder.Property(p => p.Description).HasMaxLength(Constants.FieldsDefinitions.MaxLengthDescriptions);

        builder.HasOne(p => p.Recipe)
            .WithMany()
            .HasForeignKey(p => p.RecipeId);

        builder.HasQueryFilter(p => !p.IsDeleted);
    }
}
