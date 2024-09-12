using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Caching.Memory;
using ProyectoUno.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using ProyectoDos.UI.Servicios;

namespace ProyectoUno.Controllers
{

    public class ClienteController : Controller
    {

        private readonly IServicioCliente servicioCliente;

        public ClienteController(IServicioCliente _servicioCliente) // constructor le pasa obtiene por inyeccion el cache
        {
            this.servicioCliente = _servicioCliente;
        }

        // GET: ClienteController
        public async Task<ActionResult> Index()
        {
            List<Models.Cliente> laLista;
            laLista = await servicioCliente.ObtenerListaClientes();

            return View(laLista);
        }

        // Post: ClienteController
        [HttpPost]
        public async Task<ActionResult> Index(String searchString) // hace ek netodo de buscar
        {
            ViewBag.resultado = "";
            List<Models.Cliente> laLista;
            if (!string.IsNullOrEmpty(searchString))
            {
                if ( await servicioCliente.sacarCliente(searchString) is null){ //porque no lo encontro
                    laLista = await servicioCliente.ObtenerListaClientes();
                    ViewBag.resultado = "no se encontro";
                }
                else
                {
                    ViewData["Nombre"] = "x"; // el view data guarda datos que la vista peude ver y uno lo llama
                    laLista = new List<Cliente>();
                    laLista.Add(await servicioCliente.sacarCliente(searchString));
                }
            }
            else
            {
                laLista = await servicioCliente.ObtenerListaClientes();
            }
            return View(laLista);
        }

        // GET: ClienteController/Details/5 https://es.stackoverflow.com/questions/37216/c%C3%B3mo-pasar-un-par%C3%A1metro-desde-el-home-a-otro-controlador
        public async Task<ActionResult> Details(String id)
        {
            String cedula;
            if (User.IsInRole("usuario"))
            {
                if (id is null)
                {
                    cedula = AcessoController.cedula;
                  //  cedula = TempData["request1"].ToString(); // caso de que venga la instruccuion desde acesso controlador
                }
                else { cedula = id; }

            }
            else { cedula = id; }

            Cliente cliente;
            cliente = await servicioCliente.sacarCliente(cedula);
            ViewBag.LaLista = asignarEntero();
            return View(cliente);
        }

        // GET: ClienteController/Create
        public ActionResult Create()
        {
            ViewBag.LaLista = asignarEntero();
            return View();
        }


        // POST: ClienteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Cliente cliente)
        {
            try
            {
                if (cliente.Cedula != "01-1111-1111" && await servicioCliente.sacarCliente(cliente.Cedula) is null)
                {
                    await servicioCliente.CrearCliente(cliente);
                    ModelState.Clear();
                    if (User.IsInRole("administrador"))
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ModelState.Clear();
                        ViewBag.LaLista = asignarEntero();
                        ViewBag.mensajeResultado = "!!!!!Registrado!!!!!";
                        return View();
                    }
                }
                else
                {
                    ModelState.Clear();
                    ViewBag.mensajeResultado = "!!!Ese número de cédula ya está registrado!!!";
                    ViewBag.LaLista = asignarEntero();
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }


        // GET: ClienteController/Edit/5
        public async Task<ActionResult> Edit(String id)
        {
            Cliente cliente;
            cliente = await servicioCliente.sacarCliente(id);
            ViewBag.LaLista = asignarEntero();
            return View(cliente);
        }

        // POST: ClienteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Cliente cliente, String id)
        {
            try
            {
                await servicioCliente.EditarCliente(cliente, id);

                if (User.IsInRole("administrador"))
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["request1"] = id;
                    return RedirectToAction("Details", "Cliente");
                }
            }
            catch
            {
                return View();
            }
        }


        // GET: ClienteController/Delete/5
        public async Task<ActionResult> Delete(String id)
        {
            Cliente clienteXeliminar;
            clienteXeliminar = await servicioCliente.sacarCliente(id);
            return View(clienteXeliminar);
        }

        // POST: ClienteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteAsync(String id, IFormCollection collection)
        {
            await servicioCliente.EliminarCliente(id);
            if (User.IsInRole("administrador"))
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                return RedirectToAction("Index", "Acesso");
            }

        }


        public List<SelectListItem> asignarEntero()
        {
            return new List<SelectListItem>() {
            new SelectListItem()
            {
                Text="Por un amigo",

            },
            new SelectListItem()
            {
                Text="Por redes sociales",

            },
              new SelectListItem()
            {
                Text="Porque había comprado",
            }
            };
        }
    }
}


