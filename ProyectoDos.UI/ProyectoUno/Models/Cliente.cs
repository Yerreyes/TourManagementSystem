using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;

namespace ProyectoUno.Models
{
    public class Cliente
    {
        
        [Required(ErrorMessage = "Dato requerido")]
        [RegularExpression("^(0\\d{1}-\\d{4}-\\d{4})$", ErrorMessage = "No cumple con el formato 0#-####-####")]
        public String Cedula { get; set; }

        [Required(ErrorMessage = "Dato requerido")]
        [StringLength(60, MinimumLength = 10, ErrorMessage = "El nombre debe ser mínimo de 10 caracteres y míximo de 60")]
        public String Nombre { get; set; }


        [Required(ErrorMessage = "Dato requerido")]
        [RegularExpression("^(\\d{4}$)", ErrorMessage = "No cumple con el formato del año, ####")]
        [Range(1900, 2022 - 18, ErrorMessage = "Fuera de limite, rango de 1900-2004")]
        public int FechaNacimiento { get; set; }


        [Required(ErrorMessage = "Dato requerido")]
        [RegularExpression("^(\\d{4}-\\d{4})$", ErrorMessage = "No cumple con el formato ####-####")]
        public String Telefono { get; set; }

        [Required(ErrorMessage = "Dato requerido")]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "La profesion debe ser mínimo de 10 caracteres y míximo de 100")]
        public String Profesion { get; set; }

        [Required(ErrorMessage = "Dato requerido")]
        [RegularExpression("^(\\S+@\\S+\\.\\S+)", ErrorMessage = "Formato de correo incorrecto")]
        public String Correo { get; set; }

        [Required(ErrorMessage = "Dato requerido")]
        public String Entero { get; set; }

        [Required(ErrorMessage = "Dato requerido")]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "La contraseña debe ser mínimo de 8 caracteres y maximo de 16. Con mínimo un caracter especial")]
        [RegularExpression("(?=.*[!@#$%^&*()_+}{:;'? |/>. <,])(?!. *\\s).*$", ErrorMessage = " Falta un caracter especial")]
        // [DataType(DataType.Password)]
        public String Contrasenna { get; set; }

    }
}
