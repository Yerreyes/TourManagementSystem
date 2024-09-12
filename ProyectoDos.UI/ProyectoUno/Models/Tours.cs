using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace ProyectoUno.Models
{
    public class Tours
    {
        public String Id { get; set; }

        [Required(ErrorMessage = "Dato requerido")]
        [StringLength(60, MinimumLength = 10, ErrorMessage = "Extensión mínima 10 caracteres y máximo 150 ")]
        public String Descripcion { get; set; }

        [Required(ErrorMessage = "Ruta de la imagen requerida")]
        // public byte[] Imagenc { get; set; }
        public String Imagen{ get; set; }
        public String dias { get; set; }

        [Required(ErrorMessage = "Dato Requerido")]
        [Range(0, 10000000, ErrorMessage = "precio incorrecto, rango [0-10000000]")]
        public int Precio { get; set; }


        [Required(ErrorMessage = "Dato requerido")]
        public String IDProveedor { get; set; }

        // Variable Auxiliar llevar control de cursos eliminados
        [NotMapped]
        public bool EsEliminado { get; set; }

        public override string ToString()
        {
            return "Id: " + Id + " , Descripcion: " + Descripcion + " , Dias: " + dias + " , Precio: " + Precio ;
        }
    }
}
