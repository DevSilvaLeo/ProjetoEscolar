using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto.ControleEscolar.Infra.SqlServer.Migrations
{
    /// <inheritdoc />
    public partial class InclusaoAvaliacaoeMensalidade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Avaliacao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    N1 = table.Column<decimal>(type: "decimal(2,1)", maxLength: 10, precision: 2, scale: 1, nullable: false),
                    N2 = table.Column<decimal>(type: "decimal(2,1)", maxLength: 10, precision: 2, scale: 1, nullable: false),
                    N3 = table.Column<decimal>(type: "decimal(2,1)", maxLength: 10, precision: 2, scale: 1, nullable: false),
                    Media = table.Column<decimal>(type: "decimal(2,1)", maxLength: 10, precision: 2, scale: 1, nullable: false),
                    AlunoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DisciplinaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avaliacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Avaliacao_Aluno_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Aluno",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Avaliacao_Disciplina_DisciplinaId",
                        column: x => x.DisciplinaId,
                        principalTable: "Disciplina",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Mensalidade",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false),
                    Vencimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataPagamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FormaPagamento = table.Column<int>(type: "int", nullable: false),
                    AlunoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mensalidade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mensalidade_Aluno_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Aluno",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacao_AlunoId",
                table: "Avaliacao",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacao_DisciplinaId",
                table: "Avaliacao",
                column: "DisciplinaId");

            migrationBuilder.CreateIndex(
                name: "IX_Mensalidade_AlunoId",
                table: "Mensalidade",
                column: "AlunoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Avaliacao");

            migrationBuilder.DropTable(
                name: "Mensalidade");
        }
    }
}
