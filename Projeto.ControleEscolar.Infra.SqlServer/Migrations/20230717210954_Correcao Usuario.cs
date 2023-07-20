using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto.ControleEscolar.Infra.SqlServer.Migrations
{
    /// <inheritdoc />
    public partial class CorrecaoUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "User",
                table: "Usuario",
                newName: "Email");

            migrationBuilder.RenameIndex(
                name: "IX_Usuario_User",
                table: "Usuario",
                newName: "IX_Usuario_Email");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Usuario",
                newName: "User");

            migrationBuilder.RenameIndex(
                name: "IX_Usuario_Email",
                table: "Usuario",
                newName: "IX_Usuario_User");
        }
    }
}
