using Microsoft.EntityFrameworkCore;
using ProyectoSeminarioControlNotas.Models;

namespace ProyectoSeminarioControlNotas.Models
{
    public class ProyectoDbContext : DbContext
    {
        public ProyectoDbContext(DbContextOptions<ProyectoDbContext> options) : base(options)
        {
        }

        public DbSet<Alumno> alumnos { get; set; }
        public DbSet<Curso> cursos { get; set; }
        public DbSet<ProyectoSeminarioControlNotas.Models.Carrera> Carrera { get; set; } = default!;
    }
}
