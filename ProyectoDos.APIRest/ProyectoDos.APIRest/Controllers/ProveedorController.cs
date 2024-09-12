using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoDos.APIRest.Datos;
using ProyectoDos.APIRest.Modelos;
using System.Reflection;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProyectoDos.APIRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedorController : ControllerBase
    {
        public ProveedorController( ConexionBDcontext contextBD)
        {
            
            this.contextBD = contextBD;
        }

        private readonly ConexionBDcontext contextBD;


        // GET: api/<ProveedorController>
        [HttpGet]
        public  List<Proveedor> Listar()
        {
            List<Proveedor> laLista;
            laLista = contextBD.Proveedor.ToList();
            return laLista;
        }

        // GET api/<ProveedorController>/5
        [HttpGet("{id}")]
        public Proveedor obtenerProveedor(String id)
        {
            Proveedor proveedor = contextBD.Proveedor.Find(id);
            return proveedor;
        }

        // POST api/<ProveedorController>
        [HttpPost]
        public IActionResult crearProveedor([FromBody] Proveedor proveedor)
        {
            contextBD.Proveedor.Add(proveedor);
            contextBD.SaveChanges();
            return Ok(proveedor);
        }

        // PUT api/<ProveedorController>/5
        [HttpPut("{id}")]
        public void Put(String id, [FromBody] Proveedor proveedor)//actualizar
        {
            id = proveedor.IdProveedor;
            contextBD.Entry(proveedor).State = EntityState.Modified;
            contextBD.SaveChanges();
        }

        // DELETE api/<ProveedorController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(String id)
        {

            if (contextBD.Proveedor == null)
            {
                return NotFound();
            }

            Proveedor proveedor = contextBD.Proveedor.Find(id);
            if (proveedor == null)
            {
                return NotFound();
            }

            contextBD.Proveedor.Remove(proveedor);
            contextBD.SaveChanges();
            return Ok();
        }
    }
}
