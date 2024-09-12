using ProyectoDos.APIRest.Modelos;
using System.ComponentModel.DataAnnotations;

namespace ProyectoDos.APIRest.Models
{
    public class FacturaTour
    {
        [Key]
        public int Id { get; set; }
        public String FacturaId { get; set; }
        public String TourId { get; set; }
        public Factura Factura { get; set; }
        public Tour Tour { get; set; }
    }
}
