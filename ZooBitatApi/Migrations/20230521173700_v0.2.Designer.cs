﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ZooBitatApi;

#nullable disable

namespace ZooBitatApi.Migrations
{
    [DbContext(typeof(AplicationDbContext))]
    [Migration("20230521173700_v0.2")]
    partial class v02
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ZooBitatApi.Models.Animal", b =>
                {
                    b.Property<int>("IdAnimal")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("IdEspecie")
                        .HasColumnType("int");

                    b.Property<int>("IdEstado")
                        .HasColumnType("int");

                    b.Property<int>("IdHabitat")
                        .HasColumnType("int");

                    b.Property<string>("Imagen")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Informacion")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("IdAnimal");

                    b.HasIndex("IdEspecie");

                    b.HasIndex("IdEstado");

                    b.HasIndex("IdHabitat");

                    b.ToTable("Animales");
                });

            modelBuilder.Entity("ZooBitatApi.Models.Asignacion", b =>
                {
                    b.Property<int>("IdAsignacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("UsuarioIdUsuario")
                        .HasColumnType("int");

                    b.HasKey("IdAsignacion");

                    b.HasIndex("UsuarioIdUsuario");

                    b.ToTable("Asignacion");
                });

            modelBuilder.Entity("ZooBitatApi.Models.Especie", b =>
                {
                    b.Property<int>("IdEspecie")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Icono")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Informacion")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("IdEspecie");

                    b.ToTable("Especies");
                });

            modelBuilder.Entity("ZooBitatApi.Models.Estado", b =>
                {
                    b.Property<int>("IdEstado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("IdEstado");

                    b.ToTable("Estados");
                });

            modelBuilder.Entity("ZooBitatApi.Models.EstadoAsignacion", b =>
                {
                    b.Property<int>("IdEstadoAsignacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("IdEstadoAsignacion");

                    b.ToTable("EstadosAsignacion");
                });

            modelBuilder.Entity("ZooBitatApi.Models.EstadoIncidencia", b =>
                {
                    b.Property<int>("IdEstadoIncidencia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("IdEstadoIncidencia");

                    b.ToTable("EstadosIncidencia");
                });

            modelBuilder.Entity("ZooBitatApi.Models.Habitat", b =>
                {
                    b.Property<int>("IdHabitat")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IdTipoHabitat")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("IdHabitat");

                    b.HasIndex("IdTipoHabitat");

                    b.ToTable("Habitats");
                });

            modelBuilder.Entity("ZooBitatApi.Models.HistorialEstado", b =>
                {
                    b.Property<int>("IdHistorialEstado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaInicio")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("IdAnimal")
                        .HasColumnType("int");

                    b.Property<int>("IdEstado")
                        .HasColumnType("int");

                    b.HasKey("IdHistorialEstado");

                    b.HasIndex("IdAnimal");

                    b.HasIndex("IdEstado");

                    b.ToTable("HistorialesEstado");
                });

            modelBuilder.Entity("ZooBitatApi.Models.HistorialHabitat", b =>
                {
                    b.Property<int>("IdHistorialHabitat")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("IdAnimal")
                        .HasColumnType("int");

                    b.Property<string>("Notas")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("IdHistorialHabitat");

                    b.HasIndex("IdAnimal");

                    b.ToTable("HistorialesHabitat");
                });

            modelBuilder.Entity("ZooBitatApi.Models.Incidencia", b =>
                {
                    b.Property<int>("IdIncidencia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaFinalizacion")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("FechaInicio")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("IdAnimal")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuarioMandante")
                        .HasColumnType("int");

                    b.Property<string>("Notas")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("IdIncidencia");

                    b.HasIndex("IdAnimal");

                    b.HasIndex("IdUsuario");

                    b.HasIndex("IdUsuarioMandante");

                    b.ToTable("Incidencias");
                });

            modelBuilder.Entity("ZooBitatApi.Models.Noticia", b =>
                {
                    b.Property<int>("IdNotica")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Cuerpo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<string>("Imagen")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("IdNotica");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Noticias");
                });

            modelBuilder.Entity("ZooBitatApi.Models.Rol", b =>
                {
                    b.Property<int>("IdRol")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("IdRol");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            IdRol = 1,
                            Nombre = "Administrador del zoologico"
                        },
                        new
                        {
                            IdRol = 2,
                            Nombre = "Cuidador"
                        },
                        new
                        {
                            IdRol = 3,
                            Nombre = "Veterinario"
                        },
                        new
                        {
                            IdRol = 4,
                            Nombre = "Visitante"
                        });
                });

            modelBuilder.Entity("ZooBitatApi.Models.TipoHabitat", b =>
                {
                    b.Property<int>("IdTipoHabitat")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("IdTipoHabitat");

                    b.ToTable("TiposHabitat");
                });

            modelBuilder.Entity("ZooBitatApi.Models.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Contrasenna")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("IdRol")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("IdUsuario");

                    b.HasIndex("IdRol");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("ZooBitatApi.Models.Animal", b =>
                {
                    b.HasOne("ZooBitatApi.Models.Especie", "Especie")
                        .WithMany()
                        .HasForeignKey("IdEspecie")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ZooBitatApi.Models.Estado", "Estado")
                        .WithMany()
                        .HasForeignKey("IdEstado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ZooBitatApi.Models.Habitat", "Habitat")
                        .WithMany()
                        .HasForeignKey("IdHabitat")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Especie");

                    b.Navigation("Estado");

                    b.Navigation("Habitat");
                });

            modelBuilder.Entity("ZooBitatApi.Models.Asignacion", b =>
                {
                    b.HasOne("ZooBitatApi.Models.Usuario", null)
                        .WithMany("asignaciones")
                        .HasForeignKey("UsuarioIdUsuario");
                });

            modelBuilder.Entity("ZooBitatApi.Models.Habitat", b =>
                {
                    b.HasOne("ZooBitatApi.Models.TipoHabitat", "TipoHabitat")
                        .WithMany()
                        .HasForeignKey("IdTipoHabitat")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("TipoHabitat");
                });

            modelBuilder.Entity("ZooBitatApi.Models.HistorialEstado", b =>
                {
                    b.HasOne("ZooBitatApi.Models.Animal", "Animal")
                        .WithMany()
                        .HasForeignKey("IdAnimal")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ZooBitatApi.Models.Estado", "Estado")
                        .WithMany()
                        .HasForeignKey("IdEstado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Animal");

                    b.Navigation("Estado");
                });

            modelBuilder.Entity("ZooBitatApi.Models.HistorialHabitat", b =>
                {
                    b.HasOne("ZooBitatApi.Models.Animal", "Animal")
                        .WithMany()
                        .HasForeignKey("IdAnimal")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Animal");
                });

            modelBuilder.Entity("ZooBitatApi.Models.Incidencia", b =>
                {
                    b.HasOne("ZooBitatApi.Models.Animal", "Animal")
                        .WithMany()
                        .HasForeignKey("IdAnimal")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ZooBitatApi.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ZooBitatApi.Models.Usuario", "UsuarioMandante")
                        .WithMany()
                        .HasForeignKey("IdUsuarioMandante")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Animal");

                    b.Navigation("Usuario");

                    b.Navigation("UsuarioMandante");
                });

            modelBuilder.Entity("ZooBitatApi.Models.Noticia", b =>
                {
                    b.HasOne("ZooBitatApi.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("ZooBitatApi.Models.Usuario", b =>
                {
                    b.HasOne("ZooBitatApi.Models.Rol", "Rol")
                        .WithMany()
                        .HasForeignKey("IdRol")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rol");
                });

            modelBuilder.Entity("ZooBitatApi.Models.Usuario", b =>
                {
                    b.Navigation("asignaciones");
                });
#pragma warning restore 612, 618
        }
    }
}
