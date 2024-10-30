using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace ProyectoSeminarioControlNotas.Models
{
    public class Carrera
    {
        [Key]
        public int idCarrera { get; set; }
        [Required]
        public bool estadoCarrera { get; set; } = true; // Para hacer borrado lógico y no eliminar el registro
        [DisplayName("Nombre de carrera")]
        [MaxLength(100)]
        [Required(ErrorMessage = "Ingrese nombre de la carrera.")]
        public string nombre { get; set; }
        [DisplayName("Descripción")]
        [MaxLength(100)]
        [Required(ErrorMessage = "Ingrese una descripción.")]
        public string descripcion { get; set; }
        [DisplayName("Código de carrera")]
        [Range(1, 9999, ErrorMessage = "El código de carrera debe estar entre 1 y 9999.")]
        [Required(ErrorMessage = "Ingrese un código de carrera.")]
        public int codigoCarrera { get; set; }
    }
}
