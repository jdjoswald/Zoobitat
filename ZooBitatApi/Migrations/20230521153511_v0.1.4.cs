using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZooBitatApi.Migrations
{
    /// <inheritdoc />
    public partial class v014 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Habitats_TiposHabitat_IdTipoHabitat",
                table: "Habitats");

            migrationBuilder.AddForeignKey(
                name: "FK_Habitats_TiposHabitat_IdTipoHabitat",
                table: "Habitats",
                column: "IdTipoHabitat",
                principalTable: "TiposHabitat",
                principalColumn: "IdTipoHabitat",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Habitats_TiposHabitat_IdTipoHabitat",
                table: "Habitats");

            migrationBuilder.AddForeignKey(
                name: "FK_Habitats_TiposHabitat_IdTipoHabitat",
                table: "Habitats",
                column: "IdTipoHabitat",
                principalTable: "TiposHabitat",
                principalColumn: "IdTipoHabitat",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
