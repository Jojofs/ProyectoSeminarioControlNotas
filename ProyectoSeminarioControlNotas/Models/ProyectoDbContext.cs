using Microsoft.EntityFrameworkCore;

namespace ProyectoSeminarioControlNotas.Models
{
    public class ProyectoDbContext : DbContext
    {
        public ProyectoDbContext(DbContextOptions<ProyectoDbContext> options) : base(options)
        {
        }

        public DbSet<Alumno> alumnos { get; set; }
        public DbSet<Carrera> carreras { get; set; }
        public DbSet<Pensum> pensum { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alumno>()
                .HasOne(a => a.Carrera)             // Un Alumno tiene una Carrera
                .WithMany()                         // Una Carrera puede tener muchos Alumnos, pero no lo referenciamos aquí
                .HasForeignKey(a => a.idCarrera);  // Define la clave foránea
        }
    }
}
