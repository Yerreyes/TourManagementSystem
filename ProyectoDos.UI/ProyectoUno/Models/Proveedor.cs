using System.ComponentModel.DataAnnotations;

namespace ProyectoUno.Models
{
    public class Proveedor
    {
        [Required(ErrorMessage = "Dato requerido")]
        [RegularExpression("^(0\\d{1}-\\d{4}-\\d{4})$", ErrorMessage = "No cumple con el formato 0#-####-####")]
        [StringLength(12, MinimumLength = 10, ErrorMessage = "Extensión mínima y máxima es de 10 caracteres. Cedula Física anteproner un 0 ")]
        public String IdProveedor { get; set; }


        [Required(ErrorMessage = "Dato requerido")]
        [StringLength(60, MinimumLength = 10, ErrorMessage = "Extensión mínima 10 caracteres y máximo 150 ")]
        public String Descripcion { get; set; }
    }
}
