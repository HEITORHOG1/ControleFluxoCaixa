using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleFluxoCaixa.INFRA.Migrations
{
    public partial class criacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Relatorio",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    SaldoAtual = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    TotalCreditos = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    TotalDebitos = table.Column<decimal>(type: "decimal(65,30)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relatorio", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Lancamento",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Data = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Valor = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    RelatorioId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lancamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lancamento_Relatorio_RelatorioId",
                        column: x => x.RelatorioId,
                        principalTable: "Relatorio",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Lancamento_RelatorioId",
                table: "Lancamento",
                column: "RelatorioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lancamento");

            migrationBuilder.DropTable(
                name: "Relatorio");
        }
    }
}
