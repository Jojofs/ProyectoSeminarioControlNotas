using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ProyectoSeminarioControlNotas.Models
{
    public class Carrera
    {
        [Key]
        public int idCarrera { get; set; }
        [Required]
        public bool estadoCarrera { get; set; } = true; // Para hacer borrado lógico y no eliminar el registro
        [DisplayName("Código de carrera")]
        [Required(ErrorMessage = "El código de carrera es requerido.")]
        [MaxLength(10, ErrorMessage = "El código no puede exceder los 10 caracteres.")]
        public string? codigoCarrera { get; set; }

        [DisplayName("Nombre de la carrera")]
        [Required(ErrorMessage = "El nombre de la carrera es requerido.")]
        [MaxLength(150, ErrorMessage = "El nombre del curso no puede exceder los 150 caracteres.")]
        public required string nombre { get; set; }
        [DisplayName("Número de ciclos")]
        [Required(ErrorMessage = "El número de ciclos es requerido.")]
        [Range(1, 10, ErrorMessage = "El ciclo debe estar entre 1 y 10.")]
        public int numeroCiclo { get; set; }
    }
}
