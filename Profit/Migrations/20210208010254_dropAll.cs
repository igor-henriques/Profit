using Microsoft.EntityFrameworkCore.Migrations;

namespace Profit.Migrations
{
    public partial class dropAll : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("ALTER TABLE Ingrediente RENAME COLUMN Quantia_Usada TO Quantia_Total");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("ALTER TABLE Ingrediente RENAME COLUMN Quantia_Total TO Quantia_Usada");
        }
    }
}
