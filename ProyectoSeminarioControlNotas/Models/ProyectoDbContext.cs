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
        public DbSet<Profesor> profesores { get; set; }
        public DbSet<Curso> cursos { get; set; }
        public DbSet<Calificacion> calificaciones { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relación Alumno - Carrera
            modelBuilder.Entity<Alumno>()
                .HasOne(a => a.Carrera)
                .WithMany()  // No referenciamos la colección en Carrera
                .HasForeignKey(a => a.idCarrera);

            // Relación Curso - Carrera
            modelBuilder.Entity<Curso>()
                .HasOne(c => c.Carrera)  // Un Curso tiene una Carrera
                .WithMany()              // Una Carrera puede tener muchos Cursos, pero no lo referenciamos aquí
                .HasForeignKey(c => c.idCarrera);  // Define la clave foránea para Carrera en Curso

            // Relación Curso - Profesor
            modelBuilder.Entity<Curso>()
                .HasOne(c => c.Profesor) // Un Curso tiene un Profesor
                .WithMany()              // Un Profesor puede enseñar muchos Cursos, pero no lo referenciamos aquí
                .HasForeignKey(c => c.idProfesor); // Define la clave foránea para Profesor en Curso

            // Relación Calificación - Alumno
            modelBuilder.Entity<Calificacion>()
                .HasOne(c => c.Alumno)          // Una Calificación está asociada a un Alumno
                .WithMany()                     // Un Alumno puede tener muchas Calificaciones, pero no lo referenciamos aquí
                .HasForeignKey(c => c.idAlumno) // Define la clave foránea para Alumno en Calificación
                .OnDelete(DeleteBehavior.NoAction); // Cambiar a NoAction


            // Relación Calificación - Curso
            modelBuilder.Entity<Calificacion>()
                .HasOne(c => c.Curso)           // Una Calificación está asociada a un Curso
                .WithMany()                     // Un Curso puede tener muchas Calificaciones, pero no lo referenciamos aquí
                .HasForeignKey(c => c.idCurso)  // Define la clave foránea para Curso en Calificación
                .OnDelete(DeleteBehavior.NoAction); // Cambiar a NoAction
        }
    }
}
