namespace Profit.Infrastructure.Repository.DataContext.EntityMapping;

public sealed class IngredientRecipeRelationFluentMapping : IEntityTypeConfiguration<IngredientRecipeRelation>
{
    private readonly string _schemaName;

    public IngredientRecipeRelationFluentMapping(string schemaName)
    {
        this._schemaName = schemaName;
    }

    public void Configure(EntityTypeBuilder<IngredientRecipeRelation> builder)
    {
        builder.HasKey(i => new { i.IngredientId, i.RecipeId });
        builder.ToTable("IngredientRecipeRelations", _schemaName);
        builder.Property(i => i.IngredientId).IsRequired();
        builder.Property(i => i.RecipeId).IsRequired();
        builder.Property(i => i.MeasurementUnit).IsRequired();
        builder.Property(i => i.IngredientCount).IsRequired().HasPrecision(18, 2);

        builder.HasOne(i => i.Ingredient)
            .WithMany(i => i.IngredientRecipeRelations)
            .HasForeignKey(i => i.IngredientId)
            .IsRequired();

        builder.HasOne(i => i.Recipe)
           .WithMany(i => i.IngredientRecipeRelations)
           .HasForeignKey(i => i.RecipeId)
           .IsRequired();
    }
}
