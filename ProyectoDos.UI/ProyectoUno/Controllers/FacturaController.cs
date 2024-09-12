using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoDos.UI.Models;
using ProyectoDos.UI.Servicios;
using ProyectoUno;
using ProyectoUno.Models;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace ProyectoDos.UI.Controllers
{
   
    public class FacturaController : Controller
    {
        private readonly IServicioFactura servicioFactura;

        public FacturaController(IServicioFactura servicio) // constructor le pasa obtiene por inyeccion el cache
        {
            this.servicioFactura = servicio;
        }


        // GET: FacturaController
        public async Task<ActionResult> Index()
        {
            ViewBag.resultado = "";
            List<Factura> lista = new List<Factura>();
            lista = await servicioFactura.ObtenerLista();
           
            List<Factura> listaNueva = new List<Factura>();


            foreach (Factura factura in lista.ToList())
            {
                if (AcessoController.cedula == factura.ClienteIdentificacion)
                {
                    listaNueva.Add(factura);
                }
            }
            return View(listaNueva);
        }

        // Post: ClienteController
        [HttpPost]
        public async Task<ActionResult> Index(String searchString) // hace ek netodo de buscar
        {
            ViewBag.resultado = "";
            List<Models.Factura> laLista;
            if (!string.IsNullOrEmpty(searchString))
            {
                if (await servicioFactura.sacar(searchString) is null)
                { //porque no lo encontro
                    laLista = await servicioFactura.ObtenerLista();
                    ViewBag.resultado = "no se encontro";
                }
                else
                {
                    ViewData["valor"] = "x"; // el view data guarda datos que la vista peude ver y uno lo llama
                    laLista = new List<Factura>();
                    laLista.Add(await servicioFactura.sacar(searchString));
                }
            }
            else
            {
                laLista = await servicioFactura.ObtenerLista();
            }
            return View(laLista);
        }


        // GET: FacturaController/Details/5
        public async Task<ActionResult> Details(String id)
        {
            Factura factura = new Factura();
            factura = await servicioFactura.sacar(id);

            return View(factura);
        }

        // GET: FacturaController/Create
        public async Task<ActionResult> Create()
        {

            Factura factura = new Factura();
            factura.Tours.Add(new ProyectoUno.Models.Tours() { Id = "vb", Descripcion = "", dias = "z", IDProveedor = "s", Imagen = "fd", Precio = 99 });
            factura.Productos.Add(new Producto() { id = "c", annoIngreso = 2000, descripcion = "sd", IDProveedor = "ds" });
            ViewBag.listaProductos = await servicioFactura.asignarProducto();
            ViewBag.listaTours = await servicioFactura.asignarTour();
            factura.IdFactura = hacerRan();
            return View(factura);
        }

        public static List<Factura> listaFacturasAux = new List<Factura>();
        // POST: FacturaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Factura factura)
        {
            try
            {
                factura.IdFactura = hacerRan();
                factura.ClienteIdentificacion = AcessoController.cedula;

                Factura factura1 = factura;
                factura1 = await servicioFactura.CompletarFactura(factura);
                ViewBag.listaProductos = await servicioFactura.asignarProducto();
                ViewBag.listaTours = await servicioFactura.asignarTour();


                if (listaFacturasAux.Count == 0)
                {
                    listaFacturasAux.Add(factura1);
                }
                else
                {
                    foreach (Factura item in listaFacturasAux.ToList())
                    {
                        if (item.IdFactura != factura1.IdFactura)
                        {
                            listaFacturasAux.Add(factura1);
                        }
                        else
                        {
                            listaFacturasAux.Remove(item);
                            listaFacturasAux.Add(factura1);
                        }
                    }
                }
                return View(factura);
            }
            catch
            {
                return View();
            }
        }

        // GET: FacturaController/Edit/5
        public async Task<ActionResult> Edit(String id)
        {
            Factura factura = new Factura();
            factura = await servicioFactura.sacar(id);
            ViewBag.listaProductos = await servicioFactura.asignarProducto();
            ViewBag.listaTours = await servicioFactura.asignarTour();

            return View(factura);
        }

        // POST: FacturaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(String id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FacturaController/Delete/5
        public async Task<ActionResult> Delete(String id)
        {
            Factura Xeliminar;
            Xeliminar = await servicioFactura.sacar(id);
            return View(Xeliminar);
        }

        // POST: FacturaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(String id, IFormCollection collection)
        {
            try
            {
                await servicioFactura.Eliminar(id);
                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View();
            }


        }

        // GET: FacturaController/Edit/5
        public async Task<ActionResult> probar(String id)
        {
            try
            {
                Factura facturaXguardar = new Factura();

                foreach (Factura factura in listaFacturasAux.ToList())
                {
                    if (factura.IdFactura == id)
                    {
                        facturaXguardar = factura;
                    }
                }

                await servicioFactura.Crear(facturaXguardar);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }



        public async Task<ActionResult> editar(Factura factura)// hace lo mismo de create pero retorna a la viata indicada en este caso la de ediatar porque si lo que submit al create el me retornaba a la vista del create y me interesa es mantener para llamar al metodo probar2(eidtar)
        {
            factura.ClienteIdentificacion = AcessoController.cedula;

            Factura factura1 = factura;
            factura1 = await servicioFactura.CompletarFactura(factura);
            ViewBag.listaProductos = await servicioFactura.asignarProducto();
            ViewBag.listaTours = await servicioFactura.asignarTour();


            if (listaFacturasAux.Count == 0)
            {
                listaFacturasAux.Add(factura1);
            }
            else
            {
                foreach (Factura item in listaFacturasAux.ToList())
                {
                    if (item.IdFactura != factura1.IdFactura)
                    {
                        listaFacturasAux.Add(factura1);
                    }
                    else
                    {
                        listaFacturasAux.Remove(item);
                        listaFacturasAux.Add(factura1);
                    }
                }
            }
            return View("Edit", factura);
        }


        public async Task<ActionResult> editar2(String id)
        {
            try
            {
                Factura facturaXguardar = new Factura();

                foreach (Factura factura in listaFacturasAux.ToList())
                {
                    if (factura.IdFactura == id)
                    {
                        facturaXguardar = factura;
                    }
                }
                await servicioFactura.Eliminar(id);
                await servicioFactura.Crear(facturaXguardar);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }

        public String hacerRan()
        {
            Random r = new Random();
            int i = r.Next(0, 1000);

            return "Factaa" + i;
        }

    }
}
