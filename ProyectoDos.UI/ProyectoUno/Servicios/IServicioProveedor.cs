using ProyectoUno.Models;

namespace ProyectoDos.UI.Servicios
{
    public interface IServicioProveedor
    {
        public Task<List<Proveedor>> ObtenerLista();
        public Task<Proveedor> sacar(String cedula);
        public Task<Boolean> Crear(Proveedor proveedor);
        public Task<Boolean> Eliminar(String cedula);
        public Task<Boolean> Editar(Proveedor proveedor, String id);

    }
}
