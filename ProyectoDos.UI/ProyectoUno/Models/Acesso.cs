using System.ComponentModel.DataAnnotations;

namespace ProyectoUno.Models
{
    public class Acesso
    {
        [Required(ErrorMessage = "Dato requerido")]
        [RegularExpression("^(0\\d{1}-\\d{4}-\\d{4})$", ErrorMessage = "No cumple con el formato 0#-####-####")]
        public String Id { get; set; }

        [Required(ErrorMessage = "Dato requerido")]
        [DataType(DataType.Password)]
        public String Contrasenna { get; set; }

        public string rol { get; set; }
    }
}
