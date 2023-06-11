using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZooBitatApi.Migrations
{
    /// <inheritdoc />
    public partial class mandante : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdUsuarioMandante",
                table: "AsignacionesUsuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AsignacionesUsuarios_IdUsuarioMandante",
                table: "AsignacionesUsuarios",
                column: "IdUsuarioMandante");

            migrationBuilder.AddForeignKey(
                name: "FK_AsignacionesUsuarios_Usuarios_IdUsuarioMandante",
                table: "AsignacionesUsuarios",
                column: "IdUsuarioMandante",
                principalTable: "Usuarios",
                principalColumn: "IdUsuario",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AsignacionesUsuarios_Usuarios_IdUsuarioMandante",
                table: "AsignacionesUsuarios");

            migrationBuilder.DropIndex(
                name: "IX_AsignacionesUsuarios_IdUsuarioMandante",
                table: "AsignacionesUsuarios");

            migrationBuilder.DropColumn(
                name: "IdUsuarioMandante",
                table: "AsignacionesUsuarios");
        }
    }
}
