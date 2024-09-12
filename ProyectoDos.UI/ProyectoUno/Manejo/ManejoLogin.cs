using Microsoft.Extensions.Caching.Memory;
using ProyectoDos.UI.Servicios;
using ProyectoUno.Models;

namespace ProyectoUno.Manejo
{
    public class ManejoLogin
    {
        private readonly IServicioCliente servicioCliente;
        public ManejoLogin(IServicioCliente _servicioCliente)
        {
            this.servicioCliente= _servicioCliente;

        }



        public async Task<Boolean> existe(Acesso _acces)
        {

            if (_acces.Id == "01-1111-1111" && _acces.Contrasenna!=null)
            {
                _acces.rol = "administrador";
                return true;
            }

            List<Cliente> listaClientes =await servicioCliente.ObtenerListaClientes();
            foreach (Cliente cliente in listaClientes)
            {
                if (cliente.Cedula == _acces.Id && cliente.Contrasenna == _acces.Contrasenna)
                {
                    _acces.rol = "usuario";
                    return true;
                }
            }
            return false;
        }


    }
}
