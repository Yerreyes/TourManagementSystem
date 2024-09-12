using Microsoft.AspNetCore.Mvc.Rendering;
using ProyectoUno.Models;

namespace ProyectoDos.UI.Servicios
{
    public interface IServicioProducto
    {

        public Task<List<Producto>> ObtenerLista();
        public Task<Producto> sacar(String id);
        public Task<Boolean> Crear(Producto producto);
        public Task<Boolean> Eliminar(String id);
        public Task<Boolean> Editar(Producto producto, String id);
        public List<SelectListItem> asignarProveedor(List<Proveedor> lista);

    }
}
