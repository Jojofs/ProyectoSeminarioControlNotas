using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProyectoSeminarioControlNotas.Models
{
    public class Calificacion
    {
        [Key]
        public int idCalificacion { get; set; }
        [Required]
        public bool estadoCalificacion { get; set; } = true;
        [DisplayName("Alumno")]
        [Required(ErrorMessage = "Ingrese un alumno.")]
        public int idAlumno { get; set; }
        public virtual Alumno? Alumno { get; set; }
        [DisplayName("Curso")]
        [Required(ErrorMessage = "Ingrese un curso.")]
        public int idCurso { get; set; }
        public virtual Curso? Curso { get; set; }
        [DisplayName("Parcial 1")]
        [Required(ErrorMessage = "Ingrese una nota para el parcial 1.")]
        [Range(0, 15, ErrorMessage = "La nota debe ser entre 0 y 15.")]
        public int notaParcialUno { get; set; }
        [DisplayName("Parcial 2")]
        [Required(ErrorMessage = "Ingrese una nota para el parcial 2.")]
        [Range(0, 15, ErrorMessage = "La nota debe ser entre 0 y 15.")]
        public int notaParcialDos { get; set; }
        [DisplayName("Zona")]
        [Required(ErrorMessage = "Ingrese una nota para la zona.")]
        [Range(0, 35, ErrorMessage = "La nota debe ser entre 0 y 35.")]
        public int notaZona { get; set; }
        [DisplayName("Examen final")]
        [Required(ErrorMessage = "Ingrese una nota para el examen final.")]
        [Range(0, 35, ErrorMessage = "La nota debe ser entre 0 y 35.")]
        public int notaExamen { get; set; }
        [DisplayName("Nota final")]
        [Required(ErrorMessage = "Ingrese una nota para la nota final.")]
        [Range(0, 100, ErrorMessage = "La nota debe ser entre 0 y 100.")]
        public int notaFinal { get; set; }
    }
}
