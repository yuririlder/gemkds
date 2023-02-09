using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GEMEscolar.Core.Migrations
{
    public partial class corrigindoBanco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlunoResponsavel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Responsavels",
                table: "Responsavels");

            migrationBuilder.RenameTable(
                name: "Responsavels",
                newName: "Responsavel");

            migrationBuilder.AddColumn<Guid>(
                name: "ProfessorId",
                table: "Turmas",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ResponsavelId",
                table: "Alunos",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TurmasId",
                table: "Alunos",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Responsavel",
                table: "Responsavel",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Turmas_ProfessorId",
                table: "Turmas",
                column: "ProfessorId");

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_ResponsavelId",
                table: "Alunos",
                column: "ResponsavelId");

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_TurmasId",
                table: "Alunos",
                column: "TurmasId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Responsavel_ResponsavelId",
                table: "Alunos",
                column: "ResponsavelId",
                principalTable: "Responsavel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Turmas_TurmasId",
                table: "Alunos",
                column: "TurmasId",
                principalTable: "Turmas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Turmas_Professores_ProfessorId",
                table: "Turmas",
                column: "ProfessorId",
                principalTable: "Professores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Responsavel_ResponsavelId",
                table: "Alunos");

            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Turmas_TurmasId",
                table: "Alunos");

            migrationBuilder.DropForeignKey(
                name: "FK_Turmas_Professores_ProfessorId",
                table: "Turmas");

            migrationBuilder.DropIndex(
                name: "IX_Turmas_ProfessorId",
                table: "Turmas");

            migrationBuilder.DropIndex(
                name: "IX_Alunos_ResponsavelId",
                table: "Alunos");

            migrationBuilder.DropIndex(
                name: "IX_Alunos_TurmasId",
                table: "Alunos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Responsavel",
                table: "Responsavel");

            migrationBuilder.DropColumn(
                name: "ProfessorId",
                table: "Turmas");

            migrationBuilder.DropColumn(
                name: "ResponsavelId",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "TurmasId",
                table: "Alunos");

            migrationBuilder.RenameTable(
                name: "Responsavel",
                newName: "Responsavels");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Responsavels",
                table: "Responsavels",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AlunoResponsavel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AlunoId = table.Column<Guid>(type: "uuid", nullable: false),
                    ResponsavelId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunoResponsavel", x => x.Id);
                });
        }
    }
}
