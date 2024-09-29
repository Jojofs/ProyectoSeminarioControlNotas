using Microsoft.EntityFrameworkCore;

namespace ProyectoSeminarioControlNotas.Models
{
    public class ProyectoDbContext : DbContext
    {
        public ProyectoDbContext(DbContextOptions<ProyectoDbContext> options) : base(options)
        {
        }

        public DbSet<Alumno> alumnos { get; set; }
    }
}
