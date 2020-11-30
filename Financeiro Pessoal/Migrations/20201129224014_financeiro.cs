using Microsoft.EntityFrameworkCore.Migrations;

namespace Financeiro_Pessoal.Migrations
{
    public partial class financeiro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Financeiro",
                maxLength: 60,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Observacoes",
                table: "Financeiro",
                maxLength: 120,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Financeiro");

            migrationBuilder.DropColumn(
                name: "Observacoes",
                table: "Financeiro");
        }
    }
}
