using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZooBitatApi.Migrations
{
    /// <inheritdoc />
    public partial class parte2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Partes_Animales_AnimalIdAnimal",
                table: "Partes");

            migrationBuilder.DropIndex(
                name: "IX_Partes_AnimalIdAnimal",
                table: "Partes");

            migrationBuilder.DropColumn(
                name: "AnimalIdAnimal",
                table: "Partes");

            migrationBuilder.CreateIndex(
                name: "IX_Partes_IdAnimal",
                table: "Partes",
                column: "IdAnimal");

            migrationBuilder.AddForeignKey(
                name: "FK_Partes_Animales_IdAnimal",
                table: "Partes",
                column: "IdAnimal",
                principalTable: "Animales",
                principalColumn: "IdAnimal",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Partes_Animales_IdAnimal",
                table: "Partes");

            migrationBuilder.DropIndex(
                name: "IX_Partes_IdAnimal",
                table: "Partes");

            migrationBuilder.AddColumn<int>(
                name: "AnimalIdAnimal",
                table: "Partes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Partes_AnimalIdAnimal",
                table: "Partes",
                column: "AnimalIdAnimal");

            migrationBuilder.AddForeignKey(
                name: "FK_Partes_Animales_AnimalIdAnimal",
                table: "Partes",
                column: "AnimalIdAnimal",
                principalTable: "Animales",
                principalColumn: "IdAnimal",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
