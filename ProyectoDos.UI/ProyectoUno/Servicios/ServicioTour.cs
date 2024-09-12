using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using ProyectoUno.Models;
using System.Collections.Generic;
using System.Text;

namespace ProyectoDos.UI.Servicios
{
    public class ServicioTour : IServicioTour
    {
        //toda esta parte de servicio es la que hace conexion con el api para manipular los datos aamcenados o por almacenar
        private string _baseUrl;

        public ServicioTour()
        {
            _baseUrl = "http://localhost:5089";
        }
        public async Task<Boolean> Crear(Tours tour)
        {
            tour.Imagen = "d";
            bool respuesta = false;
            var clienteServicio = new HttpClient();
            clienteServicio.BaseAddress = new Uri(_baseUrl);

            var contenido = new StringContent(JsonConvert.SerializeObject(tour), Encoding.UTF8, "application/json");
            var response = await clienteServicio.PostAsync($"api/Tour", contenido);

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }
            return respuesta;
        }



        public async Task<Boolean> Editar(Tours tour, String id)
        {
            bool respuesta = false;
            tour.Id = id;
            var serviciocliente = new HttpClient();
            serviciocliente.BaseAddress = new Uri(_baseUrl);

            var contenido = new StringContent(JsonConvert.SerializeObject(tour), Encoding.UTF8, "application/json");
            var response = await serviciocliente.PutAsync($"api/Tour/{id}", contenido);

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;

            }
            return respuesta;
        }


        public async Task<Boolean> Eliminar(String id)
        {
            bool respuesta = false;

            var serviciocliente = new HttpClient();
            serviciocliente.BaseAddress = new Uri(_baseUrl);

            var response = await serviciocliente.DeleteAsync($"api/Tour/{id}");

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;

            }
            return respuesta;
        }

        //metodo para obtener la lista de personas
        public async Task<List<Tours>> ObtenerLista()
        {
            List<Tours> lista = new List<Tours>();

            var servicioCliente = new HttpClient();
            servicioCliente.BaseAddress = new Uri(_baseUrl);

            var response = await servicioCliente.GetAsync("api/Tour");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<List<Tours>>(json_respuesta);
                lista = resultado;
            }
            return lista;
        }



        public async Task<Tours> sacar(String cedula)
        {
            Tours tour = null;

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);

            var respuesta = await cliente.GetAsync($"api/Tour/{cedula}");

            if (respuesta.IsSuccessStatusCode)
            {
                var json_respuesta = await respuesta.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<Tours>(json_respuesta);
                tour = resultado;
            }

            return tour;
        }

        public List<SelectListItem> asignarProveedor(List<Proveedor> lista)
        {
            List<SelectListItem> listItems = new List<SelectListItem>();
            foreach (var proveedor in lista)
            {
                listItems.Add(new SelectListItem()  { Text = proveedor.IdProveedor});
            }
            return listItems;
        }
    }
}
