using Microsoft.EntityFrameworkCore.Migrations;

namespace Profit.Migrations
{
    public partial class fixProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Produto_Id_Receita",
                table: "Produto",
                column: "Id_Receita");

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_Receita_Id_Receita",
                table: "Produto",
                column: "Id_Receita",
                principalTable: "Receita",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produto_Receita_Id_Receita",
                table: "Produto");

            migrationBuilder.DropIndex(
                name: "IX_Produto_Id_Receita",
                table: "Produto");

            migrationBuilder.AlterColumn<decimal>(
                name: "Quantia_Total",
                table: "Ingrediente",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
