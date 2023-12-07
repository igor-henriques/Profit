using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Profit.Infrastructure.Migrator.Migrations
{
    /// <inheritdoc />
    public partial class AddMissingFields : Migration
    {
        private readonly IDbContextSchema _schema;

        public AddMissingFields(IDbContextSchema schema)
        {
            _schema = schema ?? throw new ArgumentNullException(nameof(schema));
        }

        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                schema: _schema.Schema,
                table: "Recipes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                schema: _schema.Schema,
                table: "Products",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                schema: _schema.Schema,
                table: "OrderDetails",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                schema: _schema.Schema,
                table: "Invoices",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                schema: _schema.Schema,
                table: "Ingredients",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                schema: _schema.Schema,
                table: "Customers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                schema: _schema.Schema,
                table: "Addresses",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                schema: _schema.Schema,
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                schema: _schema.Schema,
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                schema: _schema.Schema,
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                schema: _schema.Schema,
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                schema: _schema.Schema,
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                schema: _schema.Schema,
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                schema: _schema.Schema,
                table: "Addresses");

            migrationBuilder.CreateTable(
                name: "Users",
                schema: _schema.Schema,
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    HashedPassword = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsEmailVerified = table.Column<bool>(type: "bit", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Claims",
                schema: _schema.Schema,
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Claims", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Claims_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: _schema.Schema,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Claims_UserId",
                schema: _schema.Schema,
                table: "Claims",
                column: "UserId");
        }
    }
}
