namespace Profit.Infrastructure.Repository.DataContext.EntityMapping;

public sealed class IngredientFluentMapping : IEntityTypeConfiguration<Ingredient>
{
    private readonly string _schemaName;

    public IngredientFluentMapping(string schemaName)
    {
        this._schemaName = schemaName;
    }

    public void Configure(EntityTypeBuilder<Ingredient> builder)
    {
        builder.HasKey(i => i.Id);
        builder.ToTable("Ingredients", _schemaName);
        builder.Property(i => i.Id).ValueGeneratedOnAdd();
        builder.Property(i => i.Name).IsRequired().HasMaxLength(Constants.FieldsDefinitions.MaxLengthName);
        builder.Property(i => i.Price).IsRequired().HasPrecision(18, 2);
        builder.Property(i => i.Quantity).IsRequired().HasPrecision(18, 2);
        builder.Property(i => i.ImageThumbnailUrl).HasMaxLength(Constants.FieldsDefinitions.MaxLengthImageThumbnail);
        builder.Property(i => i.MeasurementUnitType).IsRequired();
        builder.Property(i => i.Description).HasMaxLength(Constants.FieldsDefinitions.MaxLengthDescriptions);
    }
}
