using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZooBitatApi.Migrations
{
    /// <inheritdoc />
    public partial class default_data_v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Habitats",
                columns: new[] { "IdHabitat", "IdTipoHabitat", "Nombre" },
                values: new object[] { 1, 1, "habitat numero 1" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Habitats",
                keyColumn: "IdHabitat",
                keyValue: 1);
        }
    }
}
