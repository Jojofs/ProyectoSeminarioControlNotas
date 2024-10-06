using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoSeminarioControlNotas.Models
{
    public class Pensum
    {
        [Key]
        public int idPensum {  get; set; }
        [Required]
        public bool estadoPensum { get; set; } = true; // Para hacer borrado lógico y no eliminar el registro
        [DisplayName("Año de creación")]
        [Range(1999, 2025, ErrorMessage = "El año de creación debe estar entre 1999 y 2025.")]
        [Required(ErrorMessage = "Ingrese un año de creación.")]
        public int anioAprobacion { get; set; }
        [DisplayName("Carrera")]
        [Required(ErrorMessage = "Ingrese una carrera.")]
        public int idCarrera { get; set; }
        public Carrera? Carrera { get; set; }
        [DisplayName("Cantidad de ciclos")]
        [Required(ErrorMessage = "Ingrese una cantidad de ciclos del pensum.")]
        [Range(1, 10, ErrorMessage = "La cantidad de ciclos debe estar entre 1 y 10.")]
        public int cantidadCiclos { get; set; }
        [DisplayName("Cantidad de cursos por cada ciclo")]
        [Required(ErrorMessage = "Ingrese una cantidad de cursos admitidos por ciclo.")]
        [Range(1, 10, ErrorMessage = "La cantidad de cursos por ciclo debe estar entre 1 y 10.")]
        public int cantidadCursosPorCiclo { get; set; }
    }
}
