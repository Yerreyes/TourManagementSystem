using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using ProyectoDos.UI.Models;
using ProyectoUno.Models;
using System;
using System.Text;

namespace ProyectoDos.UI.Servicios
{
    public class ServicioFactura : IServicioFactura
    {
        private readonly IServicioProducto servicioProducto;
        private readonly IServicioTour servicioTour;
        private readonly IServicioCliente servicioCliente;
        //toda esta parte de servicio es la que hace conexion con el api para manipular los datos aamcenados o por almacenar
        private string _baseUrl;

        public ServicioFactura(IServicioProducto servicioProducto, IServicioTour servicioTour, IServicioCliente servicioCliente)
        {
            _baseUrl = "http://localhost:5089";
            this.servicioProducto = servicioProducto;
            this.servicioTour = servicioTour;
            this.servicioCliente = servicioCliente;
        }

        public async Task<Boolean> Crear(Factura factura)
        {
            bool respuesta = false;
            var clienteServicio = new HttpClient();
            clienteServicio.BaseAddress = new Uri(_baseUrl);


            var contenido = new StringContent(JsonConvert.SerializeObject(factura), Encoding.UTF8, "application/json");
            var response = await clienteServicio.PostAsync($"api/Factura", contenido);

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }
            return respuesta;
        }

        public async Task<Boolean> Editar(Factura factura, String id)
        {
            bool respuesta = false;
            factura.IdFactura = id;
            var serviciocliente = new HttpClient();
            serviciocliente.BaseAddress = new Uri(_baseUrl);

            var contenido = new StringContent(JsonConvert.SerializeObject(factura), Encoding.UTF8, "application/json");
            var response = await serviciocliente.PutAsync($"api/Factura/{id}", contenido);

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

            var response = await serviciocliente.DeleteAsync($"api/Factura/{cedula}");

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;

            }
            return respuesta;
        }

        //metodo para obtener la lista de personas
        public async Task<List<Factura>> ObtenerLista()
        {
            List<Factura> lista = new List<Factura>();

            var servicioCliente = new HttpClient();
            servicioCliente.BaseAddress = new Uri(_baseUrl);

            var response = await servicioCliente.GetAsync("api/Factura");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<List<Factura>>(json_respuesta);
                lista = resultado;
            }
            return lista;
        }



        public async Task<Factura> sacar(String cedula)
        {
            Factura factura = null;

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);

            var respuesta = await cliente.GetAsync($"api/Factura/{cedula}");

            if (respuesta.IsSuccessStatusCode)
            {
                var json_respuesta = await respuesta.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<Factura>(json_respuesta);
                factura = resultado;
            }
            return factura;
        }

        public async Task<List<SelectListItem>> asignarProducto()
        {

            List<Producto> lista = new List<Producto>();

            lista = await servicioProducto.ObtenerLista();
            List<SelectListItem> listItems = new List<SelectListItem>();
            foreach (var producto in lista)
            {
                listItems.Add(new SelectListItem { Value = producto.id, Text = producto.ToString() });
            }
            return listItems;
        }

        public async Task<List<SelectListItem>> asignarTour()
        {
            List<Tours> lista = new List<Tours>();
            lista = await servicioTour.ObtenerLista();

            List<SelectListItem> listItems = new List<SelectListItem>();
            foreach (var tour in lista)
            {
                listItems.Add(new SelectListItem { Value = tour.Id, Text = tour.ToString() });
            }
            return listItems;
        }


        public async Task<Factura> CompletarFactura(Factura factura)
        {
            Factura factura1 = new Factura();
            factura1 = factura;
            foreach (Tours item in factura.Tours.ToList())
            {
                if (item.EsEliminado == true)
                {
                    factura.Tours.Remove(item);
                }
            }

            foreach (Producto item in factura.Productos.ToList())
            {
                if (item.EsEliminado == true)
                {
                    factura.Productos.Remove(item);
                }
            }
            
            factura1.precioSinIva = await  calcularMontoSinIva(factura1.Productos, factura1.Tours);
            factura1.precioConIva = await calcularMontoconIva();
            return factura1;
        }

        



            Double monto = 0;
        public async Task<Double> calcularMontoSinIva(List<Producto> productos, List<Tours> tours)
        {

            //extrae toda la informacion de los productos, porque en factura solo viene id
            for (int i = 0; i < productos.Count; i++)
            {
                productos[i] = await servicioProducto.sacar(productos[i].id);
            }

            //extrae toda la informacion de los productos, porque en factura solo viene id
            for (int i = 0; i < tours.Count; i++)
            {
                tours[i] = await servicioTour.sacar(tours[i].Id);
            }


            //saco el monto
            foreach (Producto producto in productos.ToList())
            {
                monto = monto + producto.precio;
            }
            foreach (Tours tour in tours.ToList())
            {
                monto = monto + tour.Precio;
            }
            return monto;
        }

        public async Task<Double> calcularMontoconIva()
        {
            Double montoConIva = 0;
            montoConIva = monto + monto * 0.13;
            return montoConIva;
        }
    }
}