using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using ProyectoUno.Models;
using System.Text;

namespace ProyectoDos.UI.Servicios
{
    public class ServicioProducto : IServicioProducto
    {
        //toda esta parte de servicio es la que hace conexion con el api para manipular los datos aamcenados o por almacenar
        private string _baseUrl;

        public ServicioProducto()
        {
            _baseUrl = "http://localhost:5089";
        }
        public async Task<Boolean> Crear(Producto producto)
        {
            bool respuesta = false;
            var clienteServicio = new HttpClient();
            clienteServicio.BaseAddress = new Uri(_baseUrl);


            var contenido = new StringContent(JsonConvert.SerializeObject(producto), Encoding.UTF8, "application/json");
            var response = await clienteServicio.PostAsync($"api/Producto", contenido);

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }
            return respuesta;
        }

        public async Task<Boolean> Editar(Producto producto, String id)
        {
            bool respuesta = false;
            producto.id= id;
            var serviciocliente = new HttpClient();
            serviciocliente.BaseAddress = new Uri(_baseUrl);

            var contenido = new StringContent(JsonConvert.SerializeObject(producto), Encoding.UTF8, "application/json");
            var response = await serviciocliente.PutAsync($"api/Producto/{id}", contenido);

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

            var response = await serviciocliente.DeleteAsync($"api/Producto/{cedula}");

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;

            }
            return respuesta;
        }

        //metodo para obtener la lista de personas
        public async Task<List<Producto>> ObtenerLista()
        {
            List<Producto> lista = new List<Producto>();

            var servicioCliente = new HttpClient();
            servicioCliente.BaseAddress = new Uri(_baseUrl);

            var response = await servicioCliente.GetAsync("api/Producto");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<List<Producto>>(json_respuesta);
                lista = resultado;
            }
            return lista;
        }



        public async Task<Producto> sacar(String cedula)
        {
            Producto producto = null;

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);

            var respuesta = await cliente.GetAsync($"api/Producto/{cedula}");

            if (respuesta.IsSuccessStatusCode)
            {
                var json_respuesta = await respuesta.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<Producto>(json_respuesta);
                producto = resultado;
            }
            return producto;
        }

        public List<SelectListItem> asignarProveedor(List<Proveedor> lista)
        {
            List<SelectListItem> listItems = new List<SelectListItem>();
            foreach (var proveedor in lista)
            {
                listItems.Add(new SelectListItem() { Text = proveedor.IdProveedor });
            }
            return listItems;
        }
    }
}
