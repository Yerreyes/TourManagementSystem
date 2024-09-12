using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using ProyectoDos.APIRest.Datos;
using ProyectoDos.APIRest.Modelos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProyectoDos.APIRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
       
        public ClienteController( ConexionBDcontext conexionBDcontext)
        {
            this.contextBD = conexionBDcontext;
        }
        private readonly ConexionBDcontext contextBD;

        [HttpGet]
        public List<Cliente> Listar()
        {
            List<Cliente> lista = contextBD.Cliente.ToList();
            return lista;
        }

        [HttpGet("{cedula}")]
        public Cliente Buscar(string cedula)
        {
            Cliente estudiante = contextBD.Cliente.Find(cedula);/* contextBD.Cliente.Where(w => w.Cedula == cedula).FirstOrDefault()*/;
            return estudiante;
        }


        [HttpPost]
        public IActionResult Agregar([FromBody] Cliente cliente)
        {
            contextBD.Cliente.Add(cliente);
            contextBD.SaveChanges();
            return Ok(cliente);
        }

        [HttpPut("{id}")]
        public void Put(String id, [FromBody] Cliente cliente)
        {
            id = cliente.Cedula;
            contextBD.Entry(cliente).State = EntityState.Modified;
            contextBD.SaveChanges();

        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(String id)
        {
            if (contextBD.Cliente == null)
            {
                return NotFound();
            }

            Cliente cliente = contextBD.Cliente.Find(id);
            if (cliente == null)
            {
                return NotFound();
            }

            contextBD.Cliente.Remove(cliente);
            contextBD.SaveChanges();
            return Ok();
        }

    }
}
