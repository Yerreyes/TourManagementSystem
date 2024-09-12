using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoDos.APIRest.Datos;
using ProyectoDos.APIRest.Modelos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProyectoDos.APIRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        
        public ProductoController(ConexionBDcontext contextBD)
        {
            this.contextBD = contextBD;
        }

        private readonly ConexionBDcontext contextBD;

        // GET: api/<ProveedorController>
        [HttpGet]
        public List<Producto> Listar()
        {
            List<Producto> laLista;
            laLista = contextBD.Producto.ToList();
            return laLista;
        }

        // GET api/<ProveedorController>/5
        [HttpGet("{id}")]
        public Producto Buscar(string id)
        {
            Producto producto = contextBD.Producto.Find(id);
            return producto;
        }

        [HttpPost]
        public IActionResult Agregar([FromBody] Producto producto)
        {
            contextBD.Producto.Add(producto);
            contextBD.SaveChanges();
            return Ok(producto);
        }


        // PUT api/<ProveedorController>/5
        [HttpPut("{id}")]
        public void Put(String id, [FromBody] Producto producto)//actualizar
        {
            id = producto.id;
            contextBD.Entry(producto).State = EntityState.Modified;
            contextBD.SaveChanges();
        }

        // DELETE api/<ProveedorController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(String id)
        {
            if (contextBD.Producto == null)
            {
                return NotFound();
            }

            Producto producto = contextBD.Producto.Find(id);
            if (producto == null)
            {
                return NotFound();
            }

            contextBD.Producto.Remove(producto);
            contextBD.SaveChanges();
            return Ok();
        }
    }
}
