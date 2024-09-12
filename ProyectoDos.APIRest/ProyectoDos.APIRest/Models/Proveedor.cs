using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoDos.APIRest.Modelos
{
    public class Proveedor
    {
        [Key]
        public String IdProveedor { get; set; }
        public String Descripcion { get; set; }
        public Proveedor(string IdProveedor, string descripcion)
        {
            this.IdProveedor = IdProveedor;
            Descripcion = descripcion;
        }
    }

}
