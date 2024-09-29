using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ProyectoSeminarioControlNotas.Models
{
    public class Curso
    {
        [Key]
        public int idCurso { get; set; }

        [DisplayName("Código")]
        [Required(ErrorMessage = "El código del curso es requerido.")]
        [MaxLength(10, ErrorMessage = "El código no puede exceder los 10 caracteres.")]
        public string? Codigo { get; set; }

        [DisplayName("Nombre del curso")]
        [Required(ErrorMessage = "El nombre del curso es requerido.")]
        [MaxLength(150, ErrorMessage = "El nombre del curso no puede exceder los 150 caracteres.")]
        public required string Nombre { get; set; }

        [DisplayName("Requisitos")]
        [Required(ErrorMessage = "Los requisitos son requeridos.")]
        [MaxLength(10, ErrorMessage = "Los requisitos no pueden exceder los 10 caracteres.")]
        public required string Requisitos { get; set; }

        // Agregando el campo Ciclo para asignar el curso a un ciclo específico
        [DisplayName("Ciclo")]
        [Required(ErrorMessage = "El ciclo es requerido.")]
        [Range(1, 10, ErrorMessage = "El ciclo debe estar entre 1 y 10.")]
        public int Ciclo { get; set; }
    }
}
