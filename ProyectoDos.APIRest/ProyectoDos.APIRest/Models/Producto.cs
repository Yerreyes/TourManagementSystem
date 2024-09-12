using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoDos.APIRest.Modelos
{
    public class Producto
    {
        [Key]
        public String id { get; set; }
        public String descripcion { get; set; }
        public int annoIngreso { get; set; }
        public int precio { get; set; }
        public int utilidad { get; set; }

        [ForeignKey("IdProveedor")]
        public virtual string IdProveedor { get; set; }
    }
}
