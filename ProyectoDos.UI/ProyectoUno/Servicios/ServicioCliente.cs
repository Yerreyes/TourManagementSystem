using Newtonsoft.Json;
using ProyectoUno.Models;
using System.Text;

namespace ProyectoDos.UI.Servicios
{
    public class ServicioCliente : IServicioCliente
    {
        //toda esta parte de servicio es la que hace conexion con el api para manipular los datos aamcenados o por almacenar
        private string _baseUrl;

        public ServicioCliente()
        {
            _baseUrl = "http://localhost:5089";
        }
        public async Task<Boolean> CrearCliente(Cliente clienteAux)
        {
            bool respuesta = false;
            var clienteServicio = new HttpClient();
            clienteServicio.BaseAddress = new Uri(_baseUrl);


            var contenido = new StringContent(JsonConvert.SerializeObject(clienteAux), Encoding.UTF8, "application/json");
            var response = await clienteServicio.PostAsync($"api/Cliente", contenido);

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }
            return respuesta;
        }

        public async Task<Boolean> EditarCliente(Cliente cliente, String id)
        {
            bool respuesta = false;
            cliente.Cedula = id;
            var serviciocliente = new HttpClient();
            serviciocliente.BaseAddress = new Uri(_baseUrl);
           
            var contenido = new StringContent(JsonConvert.SerializeObject(cliente), Encoding.UTF8, "application/json");
            var response = await serviciocliente.PutAsync($"api/Cliente/{id}", contenido);

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;

            }
            return respuesta;
        }


        public async Task<Boolean> EliminarCliente(String cedula)
        {
            bool respuesta = false;

            var serviciocliente = new HttpClient();
            serviciocliente.BaseAddress = new Uri(_baseUrl);

            var response = await serviciocliente.DeleteAsync($"api/Cliente/{cedula}");

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;

            }
            return respuesta;
        }

        //metodo para obtener la lista de personas
        public async Task<List<Cliente>> ObtenerListaClientes()
        {
            List<Cliente> lista = new List<Cliente>();

            var servicioCliente = new HttpClient();
            servicioCliente.BaseAddress = new Uri(_baseUrl);

            var response = await servicioCliente.GetAsync("api/Cliente");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<List<Cliente>>(json_respuesta);
                lista = resultado;
            }
            return lista;
        }



        public async Task<Cliente> sacarCliente(String cedula)
        {
            Cliente clienteObtendio = null;

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);

            var respuesta = await cliente.GetAsync($"api/Cliente/{cedula}");

            if (respuesta.IsSuccessStatusCode)
            {
                var json_respuesta = await respuesta.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<Cliente>(json_respuesta);
                clienteObtendio = resultado;
            }

            return clienteObtendio;
        }




    }
}
