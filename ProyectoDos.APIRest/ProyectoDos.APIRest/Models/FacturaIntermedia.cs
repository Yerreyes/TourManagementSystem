using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ProyectoDos.APIRest.Modelos;
using System.ComponentModel.DataAnnotations;

namespace ProyectoDos.APIRest.Models
{
    public class FacturaIntermedia
    {
        [Key]
        public int id { get; set; } 
        public String FacturaId { get; set; }
        public String ProductoId { get; set; }
        public Factura Factura { get; set; }
        public Producto Producto { get; set; }
    }
}
