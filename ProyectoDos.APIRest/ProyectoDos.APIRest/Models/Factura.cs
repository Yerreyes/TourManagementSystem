using ProyectoDos.APIRest.Modelos;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoDos.APIRest.Models
{
    public class Factura
    {
        [Key]
        public String IdFactura { get; set; }
      
        public String ClienteIdentificacion { get; set; }
        public String Fecha { get; set; }
         // Variable Auxiliar llevar control de cursos eliminados
        public bool EsEliminado { get; set; }
        public double precioConIva { get; set; }
        public double precioSinIva { get; set; }
        [NotMapped]
        [ForeignKey("IdFactura")]
        public  List<Producto>? Productos{ get; set; } = new List<Producto>();
        [NotMapped]
        [ForeignKey("IdFactura")]
        public List<Tour>? Tours { get; set; } = new List<Tour>();

        

       
    }
}
