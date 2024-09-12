using Microsoft.AspNetCore.Mvc.Rendering;
using ProyectoUno.Models;

namespace ProyectoDos.UI.Servicios
{
    public interface IServicioTour
    {
        public Task<List<Tours>> ObtenerLista();
        public Task<Tours> sacar(String id);
        public Task<Boolean> Crear(Tours tour);
        public Task<Boolean> Eliminar(String id);
        public Task<Boolean> Editar( Tours tour, String id);
        public List<SelectListItem> asignarProveedor(List<Proveedor> lista);
    }

}
