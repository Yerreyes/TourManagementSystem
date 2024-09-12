using ProyectoUno.Models;

namespace ProyectoDos.UI.Servicios
{
    public interface IServicioCliente
    {
        public Task<List<Cliente>> ObtenerListaClientes();
        public Task<Cliente> sacarCliente(String cedula);
        public Task<Boolean> CrearCliente(Cliente cliente);
        public Task<Boolean> EliminarCliente(String cedula);
        public Task<Boolean> EditarCliente(Cliente cliente, String id);

    }
}
