using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoSeminarioControlNotas.Models
{
    public class Alumno
    {
        [Key]
        public int idAlumno { get; set; }
        [Required]
        public bool estadoAlumno { get; set; } = true; // Para hacer borrado lógico y no eliminar el registro
        [DisplayName("Nombre")]
        [MaxLength(100)]
        [Required(ErrorMessage = "Ingrese un nombre.")]
        public string nombre { get; set; }
        [DisplayName("Apellido")]
        [MaxLength(100)]
        [Required(ErrorMessage = "Ingrese un apellido.")]
        public string apellido { get; set; }
        [DisplayName("Carrera")]
        [MaxLength(100)]
        //PENDIENTE: realizar union 
        //[ScaffoldColumn(false)] //Sirve para que la creacion de las vistas no lo muestre
        //Necesita como parametro el dato al que hará referencia para extraer datos (relación)
        [ForeignKey ("idCarrera")]
        //[Required(ErrorMessage = "Ingrese una carrera.")] PENDIENTE: Hacer que se ingrese un valor de una lista
        public int? carrera { get; set; }
        public virtual Carrera? Carrera { get; set; }
        [DisplayName("Correo electrónico")]
        [EmailAddress(ErrorMessage = "Ingrese una dirección de correo electrónico válida.")]
        [MaxLength(255)]
        public string? correo { get; set; }
        [DisplayName("Número de teléfono")]
        [Phone(ErrorMessage = "Ingrese un número de teléfono válido.")]
        public int? numeroTelefono { get; set; }
        [DisplayName("Fecha de nacimiento")]
        [Required(ErrorMessage = "Ingrese una fecha de nacimiento.")]
        public DateOnly fechaNacimiento { get; set; }
    }
}
