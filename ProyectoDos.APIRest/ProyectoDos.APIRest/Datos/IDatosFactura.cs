
using ProyectoDos.APIRest.Modelos;
using ProyectoDos.APIRest.Models;

namespace ProyectoDos.APIRest.Datos
{
    public interface IDatosFactura
    {
        public Task<List<Factura>> ObtenerLista();
        public Task<Factura> sacar(String cedula);
        public Task<Boolean> Crear(Factura factura);
    }
}
