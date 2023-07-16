using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZooBitatApi.Migrations
{
    /// <inheritdoc />
    public partial class nuevoslogs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdUsuario",
                table: "Logs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Actividades",
                keyColumn: "Id",
                keyValue: 1,
                column: "Fecha",
                value: new DateTime(2023, 7, 15, 11, 40, 7, 753, DateTimeKind.Local).AddTicks(4913));

            migrationBuilder.UpdateData(
                table: "Actividades",
                keyColumn: "Id",
                keyValue: 2,
                column: "Fecha",
                value: new DateTime(2023, 7, 15, 11, 40, 7, 753, DateTimeKind.Local).AddTicks(5012));

            migrationBuilder.UpdateData(
                table: "Galerias",
                keyColumn: "IdGaleria",
                keyValue: 4,
                column: "IdEspecie",
                value: 1);

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "IdUsuario", "Apellido", "Contrasenna", "Email", "IdRol", "Nombre" },
                values: new object[] { 4, "nolog", "n4bQgYhMfWWaL+qgxVrQFaO/TxsrC4Is0V1sFbDwCgg=", "nolog@nolog.com", 4, "nolog" });

            migrationBuilder.CreateIndex(
                name: "IX_Logs_IdUsuario",
                table: "Logs",
                column: "IdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Logs_Usuarios_IdUsuario",
                table: "Logs",
                column: "IdUsuario",
                principalTable: "Usuarios",
                principalColumn: "IdUsuario",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Logs_Usuarios_IdUsuario",
                table: "Logs");

            migrationBuilder.DropIndex(
                name: "IX_Logs_IdUsuario",
                table: "Logs");

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "IdUsuario",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "IdUsuario",
                table: "Logs");

            migrationBuilder.UpdateData(
                table: "Actividades",
                keyColumn: "Id",
                keyValue: 1,
                column: "Fecha",
                value: new DateTime(2023, 7, 13, 22, 30, 15, 460, DateTimeKind.Local).AddTicks(9198));

            migrationBuilder.UpdateData(
                table: "Actividades",
                keyColumn: "Id",
                keyValue: 2,
                column: "Fecha",
                value: new DateTime(2023, 7, 13, 22, 30, 15, 460, DateTimeKind.Local).AddTicks(9245));

            migrationBuilder.UpdateData(
                table: "Galerias",
                keyColumn: "IdGaleria",
                keyValue: 4,
                column: "IdEspecie",
                value: 2);
        }
    }
}
