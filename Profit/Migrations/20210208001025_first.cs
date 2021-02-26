using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Profit.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Cpf = table.Column<string>(nullable: false),
                    Nome = table.Column<string>(nullable: false),
                    Tel = table.Column<string>(nullable: false),
                    Rua = table.Column<string>(nullable: true),
                    Bairro = table.Column<string>(nullable: true),
                    Num_residencia = table.Column<int>(nullable: false),
                    Referencia = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Cpf);
                });

            migrationBuilder.CreateTable(
                name: "Gasto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(nullable: false),
                    Cost = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gasto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ingrediente",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Quantia_Usada = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingrediente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Profit = table.Column<decimal>(nullable: false),
                    Id_Receita = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Receita",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Cost = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receita", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Venda",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Id_Cliente = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Data = table.Column<DateTime>(nullable: false),
                    Taxa = table.Column<decimal>(nullable: false),
                    Desconto = table.Column<decimal>(nullable: false),
                    Modalidade = table.Column<int>(nullable: false),
                    Total = table.Column<decimal>(nullable: false),
                    Troco = table.Column<decimal>(nullable: false),
                    Lucro = table.Column<decimal>(nullable: false),
                    Observation = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    Forma = table.Column<int>(nullable: false),
                    Gasto = table.Column<decimal>(nullable: false),
                    Hora = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venda", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Venda_Cliente_Id_Cliente",
                        column: x => x.Id_Cliente,
                        principalTable: "Cliente",
                        principalColumn: "Cpf",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ingrediente_Receita",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Id_Ingrediente = table.Column<int>(nullable: false),
                    Id_Receita = table.Column<int>(nullable: false),
                    Quantia_Usada = table.Column<decimal>(nullable: false),
                    Preco_Unitario = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingrediente_Receita", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ingrediente_Receita_Ingrediente_Id_Ingrediente",
                        column: x => x.Id_Ingrediente,
                        principalTable: "Ingrediente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ingrediente_Receita_Receita_Id_Receita",
                        column: x => x.Id_Receita,
                        principalTable: "Receita",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Venda_Produto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Id_Produto = table.Column<int>(nullable: false),
                    Id_Venda = table.Column<int>(nullable: false),
                    Nome_Produto = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venda_Produto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Venda_Produto_Produto_Id_Produto",
                        column: x => x.Id_Produto,
                        principalTable: "Produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Venda_Produto_Venda_Id_Venda",
                        column: x => x.Id_Venda,
                        principalTable: "Venda",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingrediente_Receita_Id_Ingrediente",
                table: "Ingrediente_Receita",
                column: "Id_Ingrediente");

            migrationBuilder.CreateIndex(
                name: "IX_Ingrediente_Receita_Id_Receita",
                table: "Ingrediente_Receita",
                column: "Id_Receita");

            migrationBuilder.CreateIndex(
                name: "IX_Venda_Id_Cliente",
                table: "Venda",
                column: "Id_Cliente");

            migrationBuilder.CreateIndex(
                name: "IX_Venda_Produto_Id_Produto",
                table: "Venda_Produto",
                column: "Id_Produto");

            migrationBuilder.CreateIndex(
                name: "IX_Venda_Produto_Id_Venda",
                table: "Venda_Produto",
                column: "Id_Venda");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Gasto");

            migrationBuilder.DropTable(
                name: "Ingrediente_Receita");

            migrationBuilder.DropTable(
                name: "Venda_Produto");

            migrationBuilder.DropTable(
                name: "Ingrediente");

            migrationBuilder.DropTable(
                name: "Receita");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "Venda");

            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
