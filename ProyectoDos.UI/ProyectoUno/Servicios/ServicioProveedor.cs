using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using ProyectoUno.Models;
using System.Text;

namespace ProyectoDos.UI.Servicios
{
    public class ServicioProveedor : IServicioProveedor 
    {
        //toda esta parte de servicio es la que hace conexion con el api para manipular los datos aamcenados o por almacenar
        private string _baseUrl;

        public ServicioProveedor()
        {
            _baseUrl = "http://localhost:5089";
        }
        public async Task<Boolean> Crear(Proveedor proveedor)
        {
            bool respuesta = false;
            var clienteServicio = new HttpClient();
            clienteServicio.BaseAddress = new Uri(_baseUrl);


            var contenido = new StringContent(JsonConvert.SerializeObject(proveedor), Encoding.UTF8, "application/json");
            var response = await clienteServicio.PostAsync($"api/Proveedor", contenido);

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }
            return respuesta;
        }

        public async Task<Boolean> Editar(Proveedor proveedor, String id)
        {
            bool respuesta = false;
            proveedor.IdProveedor = id;
            var serviciocliente = new HttpClient();
            serviciocliente.BaseAddress = new Uri(_baseUrl);

            var contenido = new StringContent(JsonConvert.SerializeObject(proveedor), Encoding.UTF8, "application/json");
            var response = await serviciocliente.PutAsync($"api/Proveedor/{id}", contenido);

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;

            }
            return respuesta;
        }


        public async Task<Boolean> Eliminar(String cedula)
        {
            bool respuesta = false;

            var serviciocliente = new HttpClient();
            serviciocliente.BaseAddress = new Uri(_baseUrl);

            var response = await serviciocliente.DeleteAsync($"api/Proveedor/{cedula}");

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;

            }
            return respuesta;
        }

        //metodo para obtener la lista de personas
        public async Task<List<Proveedor>> ObtenerLista()
        {
            List<Proveedor> lista = new List<Proveedor>();

            var servicioCliente = new HttpClient();
            servicioCliente.BaseAddress = new Uri(_baseUrl);

            var response = await servicioCliente.GetAsync("api/Proveedor");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<List<Proveedor>>(json_respuesta);
                lista = resultado;
            }
            return lista;
        }



        public async Task<Proveedor> sacar(String cedula)
        {
            Proveedor proveedor = null;

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);

            var respuesta = await cliente.GetAsync($"api/Proveedor/{cedula}");

            if (respuesta.IsSuccessStatusCode)
            {
                var json_respuesta = await respuesta.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<Proveedor>(json_respuesta);
                proveedor = resultado;
            }

            return proveedor;
        }

    }
}
