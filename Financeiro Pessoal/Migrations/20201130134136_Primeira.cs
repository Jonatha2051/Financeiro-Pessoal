using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Financeiro_Pessoal.Migrations
{
    public partial class Primeira : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
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
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
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
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CategoriaID = table.Column<int>(nullable: false),
                    IndividuoID = table.Column<int>(nullable: true),
                    Descricao = table.Column<string>(maxLength: 60, nullable: false),
                    SequenciaID = table.Column<int>(nullable: false),
                    DataEmissao = table.Column<DateTime>(nullable: false),
                    DataVencimento = table.Column<DateTime>(nullable: false),
                    Receita = table.Column<bool>(nullable: false),
                    Despesa = table.Column<bool>(nullable: false),
                    Recebido = table.Column<bool>(nullable: false),
                    Sequencia = table.Column<int>(nullable: false),
                    Valor = table.Column<double>(nullable: false),
                    Observacoes = table.Column<string>(maxLength: 120, nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "IX_Financeiro_CategoriaID",
                table: "Financeiro",
                column: "CategoriaID");

            migrationBuilder.CreateIndex(
                name: "IX_Financeiro_IndividuoID",
                table: "Financeiro",
                column: "IndividuoID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Financeiro");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Individuos");
        }
    }
}
