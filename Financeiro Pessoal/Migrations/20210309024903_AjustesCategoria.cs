using Microsoft.EntityFrameworkCore.Migrations;

namespace Financeiro_Pessoal.Migrations
{
    public partial class AjustesCategoria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Despesa",
                table: "Categorias");

            migrationBuilder.DropColumn(
                name: "Receita",
                table: "Categorias");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Categorias",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Tipo",
                table: "Categorias",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "Categorias");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Categorias",
                type: "character varying(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Despesa",
                table: "Categorias",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Receita",
                table: "Categorias",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
