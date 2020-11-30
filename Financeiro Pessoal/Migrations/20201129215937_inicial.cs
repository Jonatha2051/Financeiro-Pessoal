using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Financeiro_Pessoal.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descricao = table.Column<string>(maxLength: 20, nullable: true),
                    Receita = table.Column<bool>(nullable: false),
                    Despesa = table.Column<bool>(nullable: false),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Individuos",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(maxLength: 40, nullable: false),
                    Telefone = table.Column<string>(maxLength: 16, nullable: true),
                    Observacoes = table.Column<string>(maxLength: 120, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Individuos", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Financeiro",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoriaID = table.Column<int>(nullable: false),
                    IndividuoID = table.Column<int>(nullable: true),
                    SequenciaID = table.Column<int>(nullable: false),
                    DataEmissao = table.Column<DateTime>(nullable: false),
                    DataVencimento = table.Column<DateTime>(nullable: false),
                    Receita = table.Column<bool>(nullable: false),
                    Despesa = table.Column<bool>(nullable: false),
                    Sequencia = table.Column<int>(nullable: false),
                    Valor = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Financeiro", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Financeiro_Categorias_CategoriaID",
                        column: x => x.CategoriaID,
                        principalTable: "Categorias",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Financeiro_Individuos_IndividuoID",
                        column: x => x.IndividuoID,
                        principalTable: "Individuos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Recibos",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FinanceiroID = table.Column<int>(nullable: false),
                    DataBaixa = table.Column<DateTime>(nullable: false),
                    Valor = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recibos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Recibos_Financeiro_FinanceiroID",
                        column: x => x.FinanceiroID,
                        principalTable: "Financeiro",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Financeiro_CategoriaID",
                table: "Financeiro",
                column: "CategoriaID");

            migrationBuilder.CreateIndex(
                name: "IX_Financeiro_IndividuoID",
                table: "Financeiro",
                column: "IndividuoID");

            migrationBuilder.CreateIndex(
                name: "IX_Recibos_FinanceiroID",
                table: "Recibos",
                column: "FinanceiroID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Recibos");

            migrationBuilder.DropTable(
                name: "Financeiro");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Individuos");
        }
    }
}
