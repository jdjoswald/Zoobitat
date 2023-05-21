using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ZooBitatApi.Migrations
{
    /// <inheritdoc />
    public partial class v01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Asignacion",
                columns: table => new
                {
                    IdAsignacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asignacion", x => x.IdAsignacion);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Especies",
                columns: table => new
                {
                    IdEspecie = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Informacion = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Icono = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especies", x => x.IdEspecie);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Estados",
                columns: table => new
                {
                    IdEstado = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estados", x => x.IdEstado);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EstadosAsignacion",
                columns: table => new
                {
                    IdEstadoAsignacion = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadosAsignacion", x => x.IdEstadoAsignacion);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EstadosIncidencia",
                columns: table => new
                {
                    IdEstadoIncidencia = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadosIncidencia", x => x.IdEstadoIncidencia);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    IdRol = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.IdRol);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TiposHabitat",
                columns: table => new
                {
                    IdTipoHabitat = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposHabitat", x => x.IdTipoHabitat);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Contraseña = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Apellido = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdRol = table.Column<int>(type: "int", nullable: false),
                    RolIdRol = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.IdUsuario);
                    table.ForeignKey(
                        name: "FK_Usuarios_Roles_RolIdRol",
                        column: x => x.RolIdRol,
                        principalTable: "Roles",
                        principalColumn: "IdRol",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Habitats",
                columns: table => new
                {
                    IdHabitat = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdTipoHabitat = table.Column<int>(type: "int", nullable: false),
                    TipoHabitatIdTipoHabitat = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habitats", x => x.IdHabitat);
                    table.ForeignKey(
                        name: "FK_Habitats_TiposHabitat_TipoHabitatIdTipoHabitat",
                        column: x => x.TipoHabitatIdTipoHabitat,
                        principalTable: "TiposHabitat",
                        principalColumn: "IdTipoHabitat",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Noticias",
                columns: table => new
                {
                    IdNotica = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Titulo = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Imagen = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cuerpo = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    UsuarioIdUsuario = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Noticias", x => x.IdNotica);
                    table.ForeignKey(
                        name: "FK_Noticias_Usuarios_UsuarioIdUsuario",
                        column: x => x.UsuarioIdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Animales",
                columns: table => new
                {
                    IdAnimal = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdEspecie = table.Column<int>(type: "int", nullable: false),
                    EspecieIdEspecie = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdEstado = table.Column<int>(type: "int", nullable: false),
                    EstadoIdEstado = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IdHabitat = table.Column<int>(type: "int", nullable: false),
                    HabitatIdHabitat = table.Column<int>(type: "int", nullable: false),
                    Informacion = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Imagen = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animales", x => x.IdAnimal);
                    table.ForeignKey(
                        name: "FK_Animales_Especies_EspecieIdEspecie",
                        column: x => x.EspecieIdEspecie,
                        principalTable: "Especies",
                        principalColumn: "IdEspecie",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Animales_Estados_EstadoIdEstado",
                        column: x => x.EstadoIdEstado,
                        principalTable: "Estados",
                        principalColumn: "IdEstado",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Animales_Habitats_HabitatIdHabitat",
                        column: x => x.HabitatIdHabitat,
                        principalTable: "Habitats",
                        principalColumn: "IdHabitat",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "HistorialesEstado",
                columns: table => new
                {
                    IdHistorialEstado = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdEstado = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EstadoIdEstado = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaInicio = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IdAnimal = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AnimalIdAnimal = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistorialesEstado", x => x.IdHistorialEstado);
                    table.ForeignKey(
                        name: "FK_HistorialesEstado_Animales_AnimalIdAnimal",
                        column: x => x.AnimalIdAnimal,
                        principalTable: "Animales",
                        principalColumn: "IdAnimal",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HistorialesEstado_Estados_EstadoIdEstado",
                        column: x => x.EstadoIdEstado,
                        principalTable: "Estados",
                        principalColumn: "IdEstado",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "HistorialesHabitat",
                columns: table => new
                {
                    IdHistorialHabitat = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Fecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IdAnimal = table.Column<int>(type: "int", nullable: false),
                    AnimalIdAnimal = table.Column<int>(type: "int", nullable: false),
                    Notas = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistorialesHabitat", x => x.IdHistorialHabitat);
                    table.ForeignKey(
                        name: "FK_HistorialesHabitat_Animales_AnimalIdAnimal",
                        column: x => x.AnimalIdAnimal,
                        principalTable: "Animales",
                        principalColumn: "IdAnimal",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Incidencias",
                columns: table => new
                {
                    IdIncidencia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdAnimal = table.Column<int>(type: "int", nullable: false),
                    AnimalIdAnimal = table.Column<int>(type: "int", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaFinalizacion = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    UsuarioIdUsuario = table.Column<int>(type: "int", nullable: false),
                    IdUsuarioMandante = table.Column<int>(type: "int", nullable: false),
                    UsuarioMandanteIdUsuario = table.Column<int>(type: "int", nullable: false),
                    Notas = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incidencias", x => x.IdIncidencia);
                    table.ForeignKey(
                        name: "FK_Incidencias_Animales_AnimalIdAnimal",
                        column: x => x.AnimalIdAnimal,
                        principalTable: "Animales",
                        principalColumn: "IdAnimal",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Incidencias_Usuarios_UsuarioIdUsuario",
                        column: x => x.UsuarioIdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Incidencias_Usuarios_UsuarioMandanteIdUsuario",
                        column: x => x.UsuarioMandanteIdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "IdRol", "Nombre" },
                values: new object[,]
                {
                    { 1, "Administrador del zoologico" },
                    { 2, "Cuidador" },
                    { 3, "Veterinario" },
                    { 4, "Visitante" }
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Habitats_TipoHabitatIdTipoHabitat",
                table: "Habitats",
                column: "TipoHabitatIdTipoHabitat");

            migrationBuilder.CreateIndex(
                name: "IX_HistorialesEstado_AnimalIdAnimal",
                table: "HistorialesEstado",
                column: "AnimalIdAnimal");

            migrationBuilder.CreateIndex(
                name: "IX_HistorialesEstado_EstadoIdEstado",
                table: "HistorialesEstado",
                column: "EstadoIdEstado");

            migrationBuilder.CreateIndex(
                name: "IX_HistorialesHabitat_AnimalIdAnimal",
                table: "HistorialesHabitat",
                column: "AnimalIdAnimal");

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
                name: "IX_Noticias_UsuarioIdUsuario",
                table: "Noticias",
                column: "UsuarioIdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_RolIdRol",
                table: "Usuarios",
                column: "RolIdRol");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Asignacion");

            migrationBuilder.DropTable(
                name: "EstadosAsignacion");

            migrationBuilder.DropTable(
                name: "EstadosIncidencia");

            migrationBuilder.DropTable(
                name: "HistorialesEstado");

            migrationBuilder.DropTable(
                name: "HistorialesHabitat");

            migrationBuilder.DropTable(
                name: "Incidencias");

            migrationBuilder.DropTable(
                name: "Noticias");

            migrationBuilder.DropTable(
                name: "Animales");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Especies");

            migrationBuilder.DropTable(
                name: "Estados");

            migrationBuilder.DropTable(
                name: "Habitats");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "TiposHabitat");
        }
    }
}
