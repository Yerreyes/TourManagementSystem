using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace ProyectoUno.Models
{
    public class Producto
    {
        public String id { get; set; }

        [Required(ErrorMessage = "Dato requerido")]
        [StringLength(60, MinimumLength = 10, ErrorMessage = "Extensión mínima 10 caracteres y máximo 150 ")]
        public String descripcion { get; set; }


        [Required(ErrorMessage = "Dato requerido")]
        [RegularExpression("^(\\d{4}$)", ErrorMessage = "No cumple con el formato del año, ####")]
        [Range(1900, 2022, ErrorMessage = "Fuera de limite, rango de 1900-actualidad")]
        public int annoIngreso { get; set; }


        [Required(ErrorMessage = "Dato requerido")]
        [Range(0, 10000000, ErrorMessage = "precio incorrecto, rango [0-10000000]")]
        public int precio { get; set; }

        [Required(ErrorMessage = "Dato requerido")]
        [Range(minimum: 0, maximum: 1000000, ErrorMessage = "La utilidad debe ser un valor positivo o igual a 0, es un porcentaje")]
        public int utilidad { get; set; }


        public String IDProveedor { get; set; }

        public override string ToString()
        {
            return "Id: "+ id + " , Descripcion: " + descripcion + " , Precio: " + precio +" , Utilidad: " + utilidad + " , IdProveedor" + IDProveedor;
        }



        // Variable Auxiliar llevar control de cursos eliminados
        [NotMapped]
        public bool EsEliminado { get; set; }
    }
}
