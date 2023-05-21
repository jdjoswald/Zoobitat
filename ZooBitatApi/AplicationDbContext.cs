using Microsoft.EntityFrameworkCore;
using ZooBitatApi.Models;

namespace ZooBitatApi
{
    public class AplicationDbContext : DbContext
    {
        public DbSet<TipoHabitat> TiposHabitat { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Noticia> Noticias { get; set; }
        public DbSet<Incidencia> Incidencias { get; set; }
        public DbSet<HistorialHabitat> HistorialesHabitat { get; set; }
        public DbSet<HistorialEstado> HistorialesEstado { get; set; }
        public DbSet<Habitat> Habitats { get; set; }
        public DbSet<EstadoIncidencia> EstadosIncidencia { get; set; }
        public DbSet<EstadoAsignacion> EstadosAsignacion { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Especie> Especies { get; set; }
        public DbSet<Asignacion> Asignaciones { get; set; }
        public DbSet<Asignacion> AsignacionesUsuarios { get; set; }
        public DbSet<Animal> Animales { get; set; }

        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Habitat>()
           .HasOne(h => h.TipoHabitat)
           .WithMany()
           .HasForeignKey(h => h.IdTipoHabitat)
           .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Rol>().HasData(
                new Rol { IdRol = 1, Nombre = "Administrador del zoologico" },
                new Rol { IdRol = 2, Nombre = "Cuidador" },
                new Rol { IdRol = 3, Nombre = "Veterinario" },
                new Rol { IdRol = 4, Nombre = "Visitante" }
            );


            base.OnModelCreating(modelBuilder);
        }
    }
}
