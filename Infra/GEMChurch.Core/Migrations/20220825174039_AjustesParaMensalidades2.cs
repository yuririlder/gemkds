using Microsoft.EntityFrameworkCore.Migrations;

namespace GEMEscolar.Core.Migrations
{
    public partial class AjustesParaMensalidades2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DescontoPorcentagem",
                table: "Alunos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DescontoPorcentagem",
                table: "Alunos",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
