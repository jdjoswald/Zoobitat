using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZooBitatApi.Migrations
{
    /// <inheritdoc />
    public partial class v012 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animales_Especies_EspecieIdEspecie",
                table: "Animales");

            migrationBuilder.DropForeignKey(
                name: "FK_Animales_Estados_EstadoIdEstado",
                table: "Animales");

            migrationBuilder.DropForeignKey(
                name: "FK_Animales_Habitats_HabitatIdHabitat",
                table: "Animales");

            migrationBuilder.DropForeignKey(
                name: "FK_Habitats_TiposHabitat_TipoHabitatIdTipoHabitat",
                table: "Habitats");

            migrationBuilder.DropForeignKey(
                name: "FK_HistorialesEstado_Animales_AnimalIdAnimal",
                table: "HistorialesEstado");

            migrationBuilder.DropForeignKey(
                name: "FK_HistorialesEstado_Estados_EstadoIdEstado",
                table: "HistorialesEstado");

            migrationBuilder.DropForeignKey(
                name: "FK_HistorialesHabitat_Animales_AnimalIdAnimal",
                table: "HistorialesHabitat");

            migrationBuilder.DropForeignKey(
                name: "FK_Incidencias_Animales_AnimalIdAnimal",
                table: "Incidencias");

            migrationBuilder.DropForeignKey(
                name: "FK_Incidencias_Usuarios_UsuarioIdUsuario",
                table: "Incidencias");

            migrationBuilder.DropForeignKey(
                name: "FK_Incidencias_Usuarios_UsuarioMandanteIdUsuario",
                table: "Incidencias");

            migrationBuilder.DropForeignKey(
                name: "FK_Noticias_Usuarios_UsuarioIdUsuario",
                table: "Noticias");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Roles_RolIdRol",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_RolIdRol",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Noticias_UsuarioIdUsuario",
                table: "Noticias");

            migrationBuilder.DropIndex(
                name: "IX_Incidencias_AnimalIdAnimal",
                table: "Incidencias");

            migrationBuilder.DropIndex(
                name: "IX_Incidencias_UsuarioIdUsuario",
                table: "Incidencias");

            migrationBuilder.DropIndex(
                name: "IX_Incidencias_UsuarioMandanteIdUsuario",
                table: "Incidencias");

            migrationBuilder.DropIndex(
                name: "IX_HistorialesHabitat_AnimalIdAnimal",
                table: "HistorialesHabitat");

            migrationBuilder.DropIndex(
                name: "IX_HistorialesEstado_AnimalIdAnimal",
                table: "HistorialesEstado");

            migrationBuilder.DropIndex(
                name: "IX_HistorialesEstado_EstadoIdEstado",
                table: "HistorialesEstado");

            migrationBuilder.DropIndex(
                name: "IX_Habitats_TipoHabitatIdTipoHabitat",
                table: "Habitats");

            migrationBuilder.DropIndex(
                name: "IX_Animales_EspecieIdEspecie",
                table: "Animales");

            migrationBuilder.DropIndex(
                name: "IX_Animales_EstadoIdEstado",
                table: "Animales");

            migrationBuilder.DropIndex(
                name: "IX_Animales_HabitatIdHabitat",
                table: "Animales");

            migrationBuilder.DropColumn(
                name: "RolIdRol",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "UsuarioIdUsuario",
                table: "Noticias");

            migrationBuilder.DropColumn(
                name: "AnimalIdAnimal",
                table: "Incidencias");

            migrationBuilder.DropColumn(
                name: "UsuarioIdUsuario",
                table: "Incidencias");

            migrationBuilder.DropColumn(
                name: "UsuarioMandanteIdUsuario",
                table: "Incidencias");

            migrationBuilder.DropColumn(
                name: "AnimalIdAnimal",
                table: "HistorialesHabitat");

            migrationBuilder.DropColumn(
                name: "AnimalIdAnimal",
                table: "HistorialesEstado");

            migrationBuilder.DropColumn(
                name: "EstadoIdEstado",
                table: "HistorialesEstado");

            migrationBuilder.DropColumn(
                name: "TipoHabitatIdTipoHabitat",
                table: "Habitats");

            migrationBuilder.DropColumn(
                name: "EspecieIdEspecie",
                table: "Animales");

            migrationBuilder.DropColumn(
                name: "EstadoIdEstado",
                table: "Animales");

            migrationBuilder.DropColumn(
                name: "HabitatIdHabitat",
                table: "Animales");

            migrationBuilder.AlterColumn<int>(
                name: "IdEstado",
                table: "HistorialesEstado",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "IdAnimal",
                table: "HistorialesEstado",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "IdHistorialEstado",
                table: "HistorialesEstado",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "IdEstadoIncidencia",
                table: "EstadosIncidencia",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "IdEstadoAsignacion",
                table: "EstadosAsignacion",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "IdEstado",
                table: "Estados",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "UsuarioIdUsuario",
                table: "Asignacion",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_IdRol",
                table: "Usuarios",
                column: "IdRol");

            migrationBuilder.CreateIndex(
                name: "IX_Noticias_IdUsuario",
                table: "Noticias",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Incidencias_IdAnimal",
                table: "Incidencias",
                column: "IdAnimal");

            migrationBuilder.CreateIndex(
                name: "IX_Incidencias_IdUsuario",
                table: "Incidencias",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Incidencias_IdUsuarioMandante",
                table: "Incidencias",
                column: "IdUsuarioMandante");

            migrationBuilder.CreateIndex(
                name: "IX_HistorialesHabitat_IdAnimal",
                table: "HistorialesHabitat",
                column: "IdAnimal");

            migrationBuilder.CreateIndex(
                name: "IX_HistorialesEstado_IdAnimal",
                table: "HistorialesEstado",
                column: "IdAnimal");

            migrationBuilder.CreateIndex(
                name: "IX_HistorialesEstado_IdEstado",
                table: "HistorialesEstado",
                column: "IdEstado");

            migrationBuilder.CreateIndex(
                name: "IX_Habitats_IdTipoHabitat",
                table: "Habitats",
                column: "IdTipoHabitat");

            migrationBuilder.CreateIndex(
                name: "IX_Asignacion_UsuarioIdUsuario",
                table: "Asignacion",
                column: "UsuarioIdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Animales_IdEspecie",
                table: "Animales",
                column: "IdEspecie");

            migrationBuilder.CreateIndex(
                name: "IX_Animales_IdEstado",
                table: "Animales",
                column: "IdEstado");

            migrationBuilder.CreateIndex(
                name: "IX_Animales_IdHabitat",
                table: "Animales",
                column: "IdHabitat");

            migrationBuilder.AddForeignKey(
                name: "FK_Animales_Especies_IdEspecie",
                table: "Animales",
                column: "IdEspecie",
                principalTable: "Especies",
                principalColumn: "IdEspecie",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Animales_Estados_IdEstado",
                table: "Animales",
                column: "IdEstado",
                principalTable: "Estados",
                principalColumn: "IdEstado",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Animales_Habitats_IdHabitat",
                table: "Animales",
                column: "IdHabitat",
                principalTable: "Habitats",
                principalColumn: "IdHabitat",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Asignacion_Usuarios_UsuarioIdUsuario",
                table: "Asignacion",
                column: "UsuarioIdUsuario",
                principalTable: "Usuarios",
                principalColumn: "IdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Habitats_TiposHabitat_IdTipoHabitat",
                table: "Habitats",
                column: "IdTipoHabitat",
                principalTable: "TiposHabitat",
                principalColumn: "IdTipoHabitat",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HistorialesEstado_Animales_IdAnimal",
                table: "HistorialesEstado",
                column: "IdAnimal",
                principalTable: "Animales",
                principalColumn: "IdAnimal",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HistorialesEstado_Estados_IdEstado",
                table: "HistorialesEstado",
                column: "IdEstado",
                principalTable: "Estados",
                principalColumn: "IdEstado",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HistorialesHabitat_Animales_IdAnimal",
                table: "HistorialesHabitat",
                column: "IdAnimal",
                principalTable: "Animales",
                principalColumn: "IdAnimal",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Incidencias_Animales_IdAnimal",
                table: "Incidencias",
                column: "IdAnimal",
                principalTable: "Animales",
                principalColumn: "IdAnimal",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Incidencias_Usuarios_IdUsuario",
                table: "Incidencias",
                column: "IdUsuario",
                principalTable: "Usuarios",
                principalColumn: "IdUsuario",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Incidencias_Usuarios_IdUsuarioMandante",
                table: "Incidencias",
                column: "IdUsuarioMandante",
                principalTable: "Usuarios",
                principalColumn: "IdUsuario",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Noticias_Usuarios_IdUsuario",
                table: "Noticias",
                column: "IdUsuario",
                principalTable: "Usuarios",
                principalColumn: "IdUsuario",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Roles_IdRol",
                table: "Usuarios",
                column: "IdRol",
                principalTable: "Roles",
                principalColumn: "IdRol",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animales_Especies_IdEspecie",
                table: "Animales");

            migrationBuilder.DropForeignKey(
                name: "FK_Animales_Estados_IdEstado",
                table: "Animales");

            migrationBuilder.DropForeignKey(
                name: "FK_Animales_Habitats_IdHabitat",
                table: "Animales");

            migrationBuilder.DropForeignKey(
                name: "FK_Asignacion_Usuarios_UsuarioIdUsuario",
                table: "Asignacion");

            migrationBuilder.DropForeignKey(
                name: "FK_Habitats_TiposHabitat_IdTipoHabitat",
                table: "Habitats");

            migrationBuilder.DropForeignKey(
                name: "FK_HistorialesEstado_Animales_IdAnimal",
                table: "HistorialesEstado");

            migrationBuilder.DropForeignKey(
                name: "FK_HistorialesEstado_Estados_IdEstado",
                table: "HistorialesEstado");

            migrationBuilder.DropForeignKey(
                name: "FK_HistorialesHabitat_Animales_IdAnimal",
                table: "HistorialesHabitat");

            migrationBuilder.DropForeignKey(
                name: "FK_Incidencias_Animales_IdAnimal",
                table: "Incidencias");

            migrationBuilder.DropForeignKey(
                name: "FK_Incidencias_Usuarios_IdUsuario",
                table: "Incidencias");

            migrationBuilder.DropForeignKey(
                name: "FK_Incidencias_Usuarios_IdUsuarioMandante",
                table: "Incidencias");

            migrationBuilder.DropForeignKey(
                name: "FK_Noticias_Usuarios_IdUsuario",
                table: "Noticias");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Roles_IdRol",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_IdRol",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Noticias_IdUsuario",
                table: "Noticias");

            migrationBuilder.DropIndex(
                name: "IX_Incidencias_IdAnimal",
                table: "Incidencias");

            migrationBuilder.DropIndex(
                name: "IX_Incidencias_IdUsuario",
                table: "Incidencias");

            migrationBuilder.DropIndex(
                name: "IX_Incidencias_IdUsuarioMandante",
                table: "Incidencias");

            migrationBuilder.DropIndex(
                name: "IX_HistorialesHabitat_IdAnimal",
                table: "HistorialesHabitat");

            migrationBuilder.DropIndex(
                name: "IX_HistorialesEstado_IdAnimal",
                table: "HistorialesEstado");

            migrationBuilder.DropIndex(
                name: "IX_HistorialesEstado_IdEstado",
                table: "HistorialesEstado");

            migrationBuilder.DropIndex(
                name: "IX_Habitats_IdTipoHabitat",
                table: "Habitats");

            migrationBuilder.DropIndex(
                name: "IX_Asignacion_UsuarioIdUsuario",
                table: "Asignacion");

            migrationBuilder.DropIndex(
                name: "IX_Animales_IdEspecie",
                table: "Animales");

            migrationBuilder.DropIndex(
                name: "IX_Animales_IdEstado",
                table: "Animales");

            migrationBuilder.DropIndex(
                name: "IX_Animales_IdHabitat",
                table: "Animales");

            migrationBuilder.DropColumn(
                name: "UsuarioIdUsuario",
                table: "Asignacion");

            migrationBuilder.AddColumn<int>(
                name: "RolIdRol",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioIdUsuario",
                table: "Noticias",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AnimalIdAnimal",
                table: "Incidencias",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioIdUsuario",
                table: "Incidencias",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioMandanteIdUsuario",
                table: "Incidencias",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AnimalIdAnimal",
                table: "HistorialesHabitat",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "IdEstado",
                table: "HistorialesEstado",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "IdAnimal",
                table: "HistorialesEstado",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "IdHistorialEstado",
                table: "HistorialesEstado",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "AnimalIdAnimal",
                table: "HistorialesEstado",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "EstadoIdEstado",
                table: "HistorialesEstado",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "TipoHabitatIdTipoHabitat",
                table: "Habitats",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "IdEstadoIncidencia",
                table: "EstadosIncidencia",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<string>(
                name: "IdEstadoAsignacion",
                table: "EstadosAsignacion",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<string>(
                name: "IdEstado",
                table: "Estados",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "EspecieIdEspecie",
                table: "Animales",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "EstadoIdEstado",
                table: "Animales",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "HabitatIdHabitat",
                table: "Animales",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_RolIdRol",
                table: "Usuarios",
                column: "RolIdRol");

            migrationBuilder.CreateIndex(
                name: "IX_Noticias_UsuarioIdUsuario",
                table: "Noticias",
                column: "UsuarioIdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Incidencias_AnimalIdAnimal",
                table: "Incidencias",
                column: "AnimalIdAnimal");

            migrationBuilder.CreateIndex(
                name: "IX_Incidencias_UsuarioIdUsuario",
                table: "Incidencias",
                column: "UsuarioIdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Incidencias_UsuarioMandanteIdUsuario",
                table: "Incidencias",
                column: "UsuarioMandanteIdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_HistorialesHabitat_AnimalIdAnimal",
                table: "HistorialesHabitat",
                column: "AnimalIdAnimal");

            migrationBuilder.CreateIndex(
                name: "IX_HistorialesEstado_AnimalIdAnimal",
                table: "HistorialesEstado",
                column: "AnimalIdAnimal");

            migrationBuilder.CreateIndex(
                name: "IX_HistorialesEstado_EstadoIdEstado",
                table: "HistorialesEstado",
                column: "EstadoIdEstado");

            migrationBuilder.CreateIndex(
                name: "IX_Habitats_TipoHabitatIdTipoHabitat",
                table: "Habitats",
                column: "TipoHabitatIdTipoHabitat");

            migrationBuilder.CreateIndex(
                name: "IX_Animales_EspecieIdEspecie",
                table: "Animales",
                column: "EspecieIdEspecie");

            migrationBuilder.CreateIndex(
                name: "IX_Animales_EstadoIdEstado",
                table: "Animales",
                column: "EstadoIdEstado");

            migrationBuilder.CreateIndex(
                name: "IX_Animales_HabitatIdHabitat",
                table: "Animales",
                column: "HabitatIdHabitat");

            migrationBuilder.AddForeignKey(
                name: "FK_Animales_Especies_EspecieIdEspecie",
                table: "Animales",
                column: "EspecieIdEspecie",
                principalTable: "Especies",
                principalColumn: "IdEspecie",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Animales_Estados_EstadoIdEstado",
                table: "Animales",
                column: "EstadoIdEstado",
                principalTable: "Estados",
                principalColumn: "IdEstado",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Animales_Habitats_HabitatIdHabitat",
                table: "Animales",
                column: "HabitatIdHabitat",
                principalTable: "Habitats",
                principalColumn: "IdHabitat",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Habitats_TiposHabitat_TipoHabitatIdTipoHabitat",
                table: "Habitats",
                column: "TipoHabitatIdTipoHabitat",
                principalTable: "TiposHabitat",
                principalColumn: "IdTipoHabitat",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HistorialesEstado_Animales_AnimalIdAnimal",
                table: "HistorialesEstado",
                column: "AnimalIdAnimal",
                principalTable: "Animales",
                principalColumn: "IdAnimal",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HistorialesEstado_Estados_EstadoIdEstado",
                table: "HistorialesEstado",
                column: "EstadoIdEstado",
                principalTable: "Estados",
                principalColumn: "IdEstado",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HistorialesHabitat_Animales_AnimalIdAnimal",
                table: "HistorialesHabitat",
                column: "AnimalIdAnimal",
                principalTable: "Animales",
                principalColumn: "IdAnimal",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Incidencias_Animales_AnimalIdAnimal",
                table: "Incidencias",
                column: "AnimalIdAnimal",
                principalTable: "Animales",
                principalColumn: "IdAnimal",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Incidencias_Usuarios_UsuarioIdUsuario",
                table: "Incidencias",
                column: "UsuarioIdUsuario",
                principalTable: "Usuarios",
                principalColumn: "IdUsuario",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Incidencias_Usuarios_UsuarioMandanteIdUsuario",
                table: "Incidencias",
                column: "UsuarioMandanteIdUsuario",
                principalTable: "Usuarios",
                principalColumn: "IdUsuario",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Noticias_Usuarios_UsuarioIdUsuario",
                table: "Noticias",
                column: "UsuarioIdUsuario",
                principalTable: "Usuarios",
                principalColumn: "IdUsuario",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Roles_RolIdRol",
                table: "Usuarios",
                column: "RolIdRol",
                principalTable: "Roles",
                principalColumn: "IdRol",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
