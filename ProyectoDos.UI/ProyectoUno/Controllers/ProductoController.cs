using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Caching.Memory;
using ProyectoUno.Models;
using Microsoft.AspNetCore.Authorization;
using ProyectoDos.UI.Servicios;

namespace ProyectoUno.Controllers
{   
    [Authorize(Roles = "administrador")]
    public class ProductoController : Controller
    {
        private readonly IServicioProducto servicioProducto;
        private readonly IServicioProveedor servicioProveedor;
        public ProductoController(IServicioProducto servicioProducto, IServicioProveedor servicioProveedor) // constructor le pasa obtiene por inyeccion el cache
        {
            this.servicioProducto = servicioProducto;
            this.servicioProveedor = servicioProveedor;
        }


        // GET: ProductoController
        public async Task<ActionResult> Index()
        {
            List<Producto> laLista;
            laLista = await servicioProducto.ObtenerLista();
            return View(laLista);
        }

        // Post: ProductoController
        [HttpPost]
        public async Task<ActionResult> Index(String idBuscar) // hace el  metodo de buscar
        {
            ViewBag.resultado = "";
            List<Producto> laLista;
            if (!string.IsNullOrEmpty(idBuscar))
            {
                if (await servicioProducto.sacar(idBuscar) is null)
                { //porque no lo encontro
                    laLista = await servicioProducto.ObtenerLista();
                    ViewBag.resultado = "no se encontro";
                }
                else
                {
                    ViewData["Nombre"] = "x"; // el view data guarda datos que la vista peude ver y uno lo llama
                    laLista = new List<Producto>();
                    laLista.Add(await servicioProducto.sacar(idBuscar));
                }
            }
            else
            {
                laLista = await servicioProducto.ObtenerLista();
            }
            return View(laLista);
        }


        // GET: ProductoController/Details/5
        public async Task<ActionResult> Details(String id)
        {
            Producto producto;
            producto = await servicioProducto.sacar(id);
            return View(producto);
        }

        // GET: ProductoController/Create
        public async Task< ActionResult> Create()
        {
            ViewBag.listaProveedores = servicioProducto.asignarProveedor(await servicioProveedor.ObtenerLista());
            return View();
        }

        // POST: ProductoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult>  Create(Producto producto)
        {
            try
            {
                producto.id = hacerRan();
                await servicioProducto.Crear(producto);
                ModelState.Clear();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductoController/Edit/5
        public async Task<ActionResult> Edit(String id)
        {
            Producto producto;
            producto = await servicioProducto.sacar(id);
            ViewBag.listaProveedores = servicioProducto.asignarProveedor(await servicioProveedor.ObtenerLista());
            return View(producto);
     
        }

        // POST: ProductoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(String id, Producto producto)
        {
            try
            {
               await servicioProducto.Editar(producto, id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductoController/Delete/5
        public async Task<ActionResult> Delete(String id)
        {
            Producto producto;
            producto = await servicioProducto.sacar(id);
            return View(producto);
            
        }

        // POST: ProductoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(String id, Producto collection)
        {
            try
            {
                await servicioProducto.Eliminar(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public String hacerRan()
        {

            Random r = new Random();
            int i = r.Next(1000, 100000000);

            return "Priii-" + i;
        }

    }
}
