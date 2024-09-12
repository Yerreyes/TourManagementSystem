//fuentes para lo de roles y auntentication
//https://learn.microsoft.com/es-es/aspnet/core/security/authentication/claims?view=aspnetcore-6.0 y https://www.youtube.com/watch?v=IvoDzgrjMOY&t=762s 

using Microsoft.AspNetCore.Mvc;
using ProyectoUno.Models;
using ProyectoUno.Manejo;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using ProyectoDos.UI.Servicios;

namespace ProyectoUno
{
    public class AcessoController : Controller
    {
        private readonly IServicioCliente servicioCliente;

        public AcessoController(IServicioCliente _servicioCliente) // constructor le pasa obtiene por inyeccion el cache
        {
            this.servicioCliente = _servicioCliente;
        }

        public IActionResult Index()
        {
            return View();

        }

        public static string cedula = "";
        [HttpPost]
        public async Task<IActionResult> Index(Acesso _acceso)
        {
            ManejoLogin manejoLogin = new ManejoLogin(servicioCliente);

            if (await manejoLogin.existe(_acceso))
            {
                ViewBag.mesaje = "";
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, _acceso.Id),
                    new Claim("Contrasenna", _acceso.Contrasenna),
                    new Claim(ClaimTypes.Role, _acceso.rol)
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                if (User.IsInRole("administrador") || _acceso.rol == "administrador")
                {
                    cedula = _acceso.Id.ToString();
                    return RedirectToAction("Index", "Cliente");
                }
                else {
                    cedula = _acceso.Id.ToString();
                    TempData["request1"] = _acceso.Id; // el temptada permite pasar informacion de un controler a otro
                    return RedirectToAction("Details", "Cliente");
                }

            }
            else
            {
                if (_acceso.Id != null)
                {
                    ViewBag.mesaje = "!!!No esta registrado o verificar la contrasena!!!";
                }
            }

            return View();
        }


        public async Task<IActionResult> Salir()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Acesso");
        }

    }
}
