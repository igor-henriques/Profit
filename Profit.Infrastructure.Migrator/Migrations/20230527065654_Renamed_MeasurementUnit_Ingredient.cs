#nullable disable

namespace Profit.Infrastructure.Migrator.Migrations
{
    /// <inheritdoc />
    public partial class RenamedMeasurementUnitIngredient : Migration
    {
        private readonly IDbContextSchema _schema;

        public RenamedMeasurementUnitIngredient(IDbContextSchema schema)
        {
            _schema = schema ?? throw new ArgumentNullException(nameof(schema));
        }

        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MeasurementUnit",
                table: "Ingredients",
                newName: "MeasurementUnit",
                schema: _schema.Schema);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MeasurementUnit",
                table: "Ingredients",
                newName: "MeasurementUnit",
                schema: _schema.Schema);
        }
    }
}
