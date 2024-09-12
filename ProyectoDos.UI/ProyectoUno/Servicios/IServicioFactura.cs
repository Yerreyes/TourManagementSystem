using Microsoft.AspNetCore.Mvc.Rendering;
using ProyectoDos.UI.Models;
using ProyectoUno.Models;

namespace ProyectoDos.UI.Servicios
{
    public interface IServicioFactura
    {
        public Task<List<Factura>> ObtenerLista();
        public Task<Factura> sacar(String id);
        public Task<Boolean> Crear(Factura factura);
        public Task<Boolean> Eliminar(String id);
        public Task<Boolean> Editar(Factura factura, String id);
        public Task<List<SelectListItem> >asignarProducto();
        public Task<List<SelectListItem>> asignarTour();
        public Task<Factura> CompletarFactura(Factura factura);

    }
}
