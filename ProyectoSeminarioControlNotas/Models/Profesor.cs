﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProyectoSeminarioControlNotas.Models
{
    public class Profesor
    {
        [Key]
        public int idProfesor { get; set; }
        [Required]
        public bool estadoProfesor { get; set; } = true; // Para hacer borrado lógico y no eliminar el registro
        [DisplayName("Nombre")]
        [MaxLength(100)]
        [Required(ErrorMessage = "Ingrese un nombre.")]
        public string nombre { get; set; }
        [DisplayName("Apellido")]
        [MaxLength(100)]
        [Required(ErrorMessage = "Ingrese un apellido.")]
        public string apellido { get; set; }
        [DisplayName("Correo electrónico")]
        [EmailAddress(ErrorMessage = "Ingrese una dirección de correo electrónico válida.")]
        [Required(ErrorMessage = "Ingrese un correo electrónico.")]
        [MaxLength(255)]
        public string correo { get; set; }
        [DisplayName("Número de teléfono")]
        [Required(ErrorMessage = "Ingrese un número de teléfono.")]
        [Range(10000000, 99999999, ErrorMessage = "El número debe tener exactamente 8 dígitos.")]
        public int numeroTelefono { get; set; }
        [DisplayName("Fecha de nacimiento")]
        [Required(ErrorMessage = "Ingrese una fecha de nacimiento.")]
        public DateOnly fechaNacimiento { get; set; }
    }
}
