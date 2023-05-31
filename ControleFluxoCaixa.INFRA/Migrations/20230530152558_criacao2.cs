using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleFluxoCaixa.INFRA.Migrations
{
    public partial class criacao2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lancamento_Relatorio_RelatorioId",
                table: "Lancamento");

            migrationBuilder.DropIndex(
                name: "IX_Lancamento_RelatorioId",
                table: "Lancamento");

            migrationBuilder.DropColumn(
                name: "RelatorioId",
                table: "Lancamento");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "RelatorioId",
                table: "Lancamento",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_Lancamento_RelatorioId",
                table: "Lancamento",
                column: "RelatorioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lancamento_Relatorio_RelatorioId",
                table: "Lancamento",
                column: "RelatorioId",
                principalTable: "Relatorio",
                principalColumn: "Id");
        }
    }
}
