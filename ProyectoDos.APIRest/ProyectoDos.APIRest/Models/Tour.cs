using ProyectoDos.APIRest.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoDos.APIRest.Modelos
{
    public class Tour
    {
        [Key]
        public String Id { get; set; }
        public String Descripcion { get; set; }
        public String Imagen { get; set; }
        public String dias { get; set; }
        public int Precio { get; set; }

        [ForeignKey("IdProveedor")]
        public virtual string IdProveedor { get;set; }
        public Tour(string id, string descripcion, string imagen, string dias, int precio, string idProveedor)
        {
            Id = id;
            Descripcion = descripcion;
            Imagen = imagen;
            this.dias = dias;
            Precio= precio;
            IdProveedor = idProveedor;  
        }
    }
}
