using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GEMEscolar.Core.Migrations
{
    public partial class AjustesParaMensalidades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProfessoresTurmas");

            migrationBuilder.AddColumn<Guid>(
                name: "AlunosId",
                table: "Mensalidades",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DescontoPorcentagem",
                table: "Mensalidades",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Valor",
                table: "Mensalidades",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "DescontoPorcentagem",
                table: "Alunos",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Mensalidades_AlunosId",
                table: "Mensalidades",
                column: "AlunosId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mensalidades_Alunos_AlunosId",
                table: "Mensalidades",
                column: "AlunosId",
                principalTable: "Alunos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mensalidades_Alunos_AlunosId",
                table: "Mensalidades");

            migrationBuilder.DropIndex(
                name: "IX_Mensalidades_AlunosId",
                table: "Mensalidades");

            migrationBuilder.DropColumn(
                name: "AlunosId",
                table: "Mensalidades");

            migrationBuilder.DropColumn(
                name: "DescontoPorcentagem",
                table: "Mensalidades");

            migrationBuilder.DropColumn(
                name: "Valor",
                table: "Mensalidades");

            migrationBuilder.DropColumn(
                name: "DescontoPorcentagem",
                table: "Alunos");

            migrationBuilder.CreateTable(
                name: "ProfessoresTurmas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProfssoresId = table.Column<Guid>(type: "uuid", nullable: false),
                    TurmasId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfessoresTurmas", x => x.Id);
                });
        }
    }
}
