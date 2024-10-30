using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProyectoSeminarioControlNotas.Models
{
    public class Curso
    {
        [Key]
        public int idCurso { get; set; }
        [Required]
        public bool estadoCurso { get; set; } = true; // Para hacer borrado lógico y no eliminar el registro
        [DisplayName("Nombre")]
        [Required(ErrorMessage = "Ingrese el nombre del curso.")]
        public string nombre { get; set; }
        [DisplayName("Código de curso")]
        [Required(ErrorMessage = "Ingrese un código de curso.")]
        [Range(1, 9999, ErrorMessage = "El código debe tener entre 1 y 9999.")]
        public int codigoCurso { get; set; }
        [DisplayName("Carrera")]
        [Required(ErrorMessage = "Ingrese una carrera.")]
        public int idCarrera { get; set; }
        public virtual Carrera? Carrera { get; set; }
        [DisplayName("Profesor encargado")]
        [Required(ErrorMessage = "Ingrese un profesor.")]
        public int idProfesor { get; set; }
        public virtual Profesor? Profesor { get; set; }
    }
}
