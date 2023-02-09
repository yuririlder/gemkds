using Microsoft.EntityFrameworkCore.Migrations;

namespace GEMEscolar.Core.Migrations
{
    public partial class AjustesParaTurmas2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "Professores",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Professores");
        }
    }
}
