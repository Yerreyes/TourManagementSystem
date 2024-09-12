using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProyectoUno.Models;
using Microsoft.AspNetCore.Authorization;
using ProyectoDos.UI.Servicios;


namespace ProyectoUno.Controllers
{
    [Authorize(Roles = "administrador")]
    public class ToursController : Controller
    {
        private readonly IServicioTour servicioTour;
        private readonly IServicioProveedor servicioProveedor;

        public ToursController(IServicioTour servicioTour, IServicioProveedor servicioProveedor) // constructor le pasa obtiene por inyeccion el cache
        {
            this.servicioTour = servicioTour;
            this.servicioProveedor = servicioProveedor;
        }
        // GET: ToursController
        public async Task<ActionResult> Index()
        {
            List<Tours> laLista;
            laLista = await servicioTour.ObtenerLista();
            return View(laLista);
        }

        // Post: ToursController
        [HttpPost]
        public async Task<ActionResult> Index(String idBuscar) // hace el  metodo de buscar
        {
            ViewBag.resultado = "";

            List<Tours> laLista;
            if (!string.IsNullOrEmpty(idBuscar))
            {
                if (await servicioTour.sacar(idBuscar) is null)
                { //porque no lo encontro
                    laLista = await servicioTour.ObtenerLista();
                    ViewBag.resultado = "No se encontro";
                }
                else
                {
                    ViewData["Nombre"] = "x"; // el view data guarda datos que la vista peude ver y uno lo llama
                    laLista = new List<Tours>();
                    laLista.Add(await servicioTour.sacar(idBuscar));
                }
            }
            else
            {
                laLista = await servicioTour.ObtenerLista();
            }
            return View(laLista);
        }

        // GET: ToursController/Details/5
        public async Task<ActionResult> Details(String id)
        {
            Tours tour;
            tour = await servicioTour.sacar(id);
            return View(tour);
        }

        // GET: ToursController/Create
        public async Task<ActionResult> Create()
        {
            ViewBag.listaDias = asignarDias();
            ViewBag.listaProveedores = servicioTour.asignarProveedor(await servicioProveedor.ObtenerLista());
            return View();
        }

        // POST: ToursController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Tours tour/*, IList<IFormFile> Imagenc*/)
        {
            try
            {
                /*
                IFormFile file = Imagenc.FirstOrDefault();
                if (file.ContentType.ToLower().StartsWith("image/"))
                {
                    using (BinaryReader read = new BinaryReader(file.OpenReadStream()))
                    {
                      //  tour.Imagenc = read.ReadBytes((int)file.OpenReadStream().Length);

                    }
                }*/
               
                tour.Id = hacerRan();
                await servicioTour.Crear(tour);
                ModelState.Clear();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ToursController/Edit/5
        public async Task<ActionResult> Edit(String id)
        {
            Tours tour;
            tour = await servicioTour.sacar(id);
            ViewBag.listaDias = asignarDias();
            ViewBag.listaProveedores = servicioTour.asignarProveedor(await servicioProveedor.ObtenerLista());
            return View(tour);
        }

        // POST: ToursController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(String id, Tours tour)
        {
            try
            {
                tour.Imagen = "d";
                await servicioTour.Editar(tour, id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ToursController/Delete/5
        public async Task<ActionResult> Delete(String id)
        {
            Tours tour;
            tour = await servicioTour.sacar(id);
            return View(tour);
        }

        // POST: ToursController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(String id, Tours tour)
        {
            try
            {
                await servicioTour.Eliminar(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        public List<SelectListItem> asignarDias()
        {
            return new List<SelectListItem>() {
            new SelectListItem()
            {
                Text="Lunes a Viernes",

            },
            new SelectListItem()
            {
                Text="Sábado y Domingo",

            },
             new SelectListItem()
            {
                Text="Sólo Sábado",

            },
              new SelectListItem()
            {
                Text="Sólo domingo",
            }
            };
        }

        public String hacerRan()
        {

            Random r = new Random();
            int i = r.Next(1000, 100000000);

            return "Tourxx-" + i;
        }


    }
}
