using ProyectoUno.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoDos.UI.Models
{
    public class Factura
    {
        public String IdFactura { get; set; }
        public String ClienteIdentificacion { get; set; } = "";
        public String Fecha { get; set; }  
        public virtual List<Producto> Productos { get; set; } = new List<Producto>();
        public virtual List<Tours> Tours { get; set; } = new List<Tours>();
       
        // Variable Auxiliar llevar control de cursos eliminados
        [NotMapped]
        public bool EsEliminado { get; set; }
        public double precioConIva { get; set; } =0;
        public double precioSinIva { get; set; } = 0;
    }
}
