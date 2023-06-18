using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZooBitatApi.Migrations
{
    /// <inheritdoc />
    public partial class descripcionhabitat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Habitats",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Habitats",
                keyColumn: "IdHabitat",
                keyValue: 1,
                column: "Descripcion",
                value: "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc in ex quis neque eleifend hendrerit. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Donec cursus a dolor vel aliquet. Donec rhoncus ornare lorem id ullamcorper. Donec viverra ligula dui, vel commodo dolor faucibus ultrices. Nunc eu pellentesque nisi, nec scelerisque lectus. Praesent at eleifend nibh. Sed pellentesque lectus tellus, nec mollis tortor mollis eu. Nam imperdiet eros ac varius ultrices. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Vestibulum eleifend est porttitor mi consectetur tempus. Donec nec eros sed nibh facilisis egestas. Morbi non accumsan sapien, sed bibendum quam. Cras in sapien a elit aliquet sollicitudin in id augue.");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Habitats");
        }
    }
}
