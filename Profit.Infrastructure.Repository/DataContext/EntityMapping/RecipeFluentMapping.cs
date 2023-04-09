namespace Profit.Infrastructure.Repository.DataContext.EntityMapping;

public sealed class RecipeFluentMapping : IEntityTypeConfiguration<Recipe>
{
    public void Configure(EntityTypeBuilder<Recipe> builder)
    {
        builder.HasKey(r => r.Id);
        builder.ToTable("Recipes");
        builder.Property(r => r.Id).ValueGeneratedOnAdd();
        builder.Property(r => r.Name).IsRequired().HasMaxLength(Constants.FieldsDefinitions.MaxLengthName);
        builder.Property(r => r.TotalCost).IsRequired().HasPrecision(18, 2);
        builder.Property(r => r.Description).HasMaxLength(Constants.FieldsDefinitions.MaxLengthDescriptions);
    }
}
