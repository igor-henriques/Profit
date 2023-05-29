using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Profit.Infrastructure.Migrator.Migrations
{
    /// <inheritdoc />
    public partial class Add_IsDelete_Column : Migration
    {
        private readonly IDbContextSchema _schema;

        public Add_IsDelete_Column(IDbContextSchema schema)
        {
            _schema = schema ?? throw new ArgumentNullException(nameof(schema));
        }

        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Recipes",
                type: "bit",
                nullable: false,
                defaultValue: false,
                schema: _schema.Schema);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false,
                schema: _schema.Schema);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Ingredients",
                type: "bit",
                nullable: false,
                defaultValue: false,
                schema: _schema.Schema);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Recipes",
                schema: _schema.Schema);

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Products",
                schema: _schema.Schema);

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Ingredients",
                schema: _schema.Schema);
        }
    }
}
