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
        [Range(0, 15, ErrorMessage = "La nota debe ser entre 0 y 15.")]
        public int? notaParcialUno { get; set; }
        [DisplayName("Parcial 2")]
        [Range(0, 15, ErrorMessage = "La nota debe ser entre 0 y 15.")]
        public int? notaParcialDos { get; set; }
        [DisplayName("Zona")]
        [Range(0, 35, ErrorMessage = "La nota debe ser entre 0 y 35.")]
        public int? notaZona { get; set; }
        [DisplayName("Examen final")]
        [Range(0, 35, ErrorMessage = "La nota debe ser entre 0 y 35.")]
        public int? notaExamen { get; set; }
        [DisplayName("Nota final")]
        [Range(0, 100, ErrorMessage = "La nota debe ser entre 0 y 100.")]
        public int? notaFinal { get; set; }
        public void CalcularNotaFinal()
        {
            notaFinal = (notaParcialUno ?? 0) + (notaParcialDos ?? 0) + (notaZona ?? 0) + (notaExamen ?? 0);
        }
    }
}
