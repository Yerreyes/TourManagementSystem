using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Caching.Memory;
using ProyectoDos.UI.Servicios;
using ProyectoUno.Models;
using System.Data;

namespace ProyectoUno.Controllers
{
    [Authorize(Roles = "administrador")]
    public class ProveedorController : Controller
    {
        private readonly IServicioProveedor servicioProveedor;

        public ProveedorController(IServicioProveedor _servicioProveedor) // constructor le pasa obtiene por inyeccion el cache
        {
            this.servicioProveedor = _servicioProveedor;
        }

        // GET: ProveedorController
        public async Task<ActionResult> Index()
        {
            List<Models.Proveedor> laLista;
            laLista = await servicioProveedor.ObtenerLista();
            return View(laLista);
        }

        // Post: ProveedorController
        [HttpPost]
        public async Task<ActionResult> Index(String idBuscar) // hace el  metodo de buscar
        {
            ViewBag.resultado = "";
            List<Proveedor> laLista;
            if (!string.IsNullOrEmpty(idBuscar))
            {
                if (await servicioProveedor.sacar(idBuscar) is null)
                { //porque no lo encontro
                    laLista = await servicioProveedor.ObtenerLista();
                    ViewBag.resultado = "No se encontro";
                }
                else
                {
                    ViewData["Nombre"] = "x"; // el view data guarda datos que la vista peude ver y uno lo llama
                    laLista = new List<Proveedor>();
                    laLista.Add(await servicioProveedor.sacar(idBuscar));
                }
            }
            else
            {
                laLista = await servicioProveedor.ObtenerLista();
            }
            return View(laLista);
        }

        // GET: ProveedorController/Details/5
        public async Task<ActionResult> Details(String id)
        {
            Proveedor proveedor;
            proveedor = await servicioProveedor.sacar(id);
            return View(proveedor);
        }

        // GET: ProveedorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProveedorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Proveedor proveedor)
        {
            try
            {
                await servicioProveedor.Crear(proveedor);
                ModelState.Clear();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProveedorController/Edit/5
        public async Task<ActionResult> Edit(String id)
        {
            Proveedor proveedor;
            proveedor = await servicioProveedor.sacar(id);
            return View(proveedor);
        }

        // POST: ProveedorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(String id, Proveedor proveedor)
        {
            try
            {
                await servicioProveedor.Editar(proveedor, id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProveedorController/Delete/5
        public async Task<ActionResult> Delete(String id)
        {
            Proveedor proveedor;
            proveedor = await servicioProveedor.sacar(id);
            return View(proveedor);
        }

        // POST: ProveedorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(String id, Proveedor proveedor)
        {
            try
            {
                await servicioProveedor.Eliminar(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
