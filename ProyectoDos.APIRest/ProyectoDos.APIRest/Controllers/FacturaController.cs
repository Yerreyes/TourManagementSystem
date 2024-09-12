using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using ProyectoDos.APIRest.Datos;
using ProyectoDos.APIRest.Modelos;
using ProyectoDos.APIRest.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProyectoDos.APIRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        private readonly IDatosFactura datosFactura;
        public FacturaController(IDatosFactura datosFactura, ConexionBDcontext contextBD)
        {
            this.datosFactura = datosFactura;
            this.contextBD = contextBD;
        }

        private readonly ConexionBDcontext contextBD;
         // GET: api/<FacturaController>
        [HttpGet]
        public async Task<List<Factura>> Listar()
        {
            List<Factura> lista;
            lista = await  datosFactura.ObtenerLista();
            return lista;

            //List<Factura> lista;
            //Cliente cliente = new Cliente() { Cedula="12"};

            //lista =  contextBD.Factura.ToList();
            //lista[0].Cliente = cliente;
            //return (lista);
        }

        // GET api/<FacturaController>/5
        [HttpGet("{id}")]
        public async Task<Factura> Obtener(String id)
        {
            Factura factura;
           // factura = contextBD.Factura.Find(id);
            factura = await datosFactura.sacar(id);
            //factura = facturas.FirstOrDefault().Where(w => w.id = id).Single()
            return factura;
        }
        
        // POST api/<FacturaController>
        [HttpPost]
        public ActionResult Crear([FromBody] Factura factura)
        {
            datosFactura.Crear(factura);
            return Ok(factura);
        }

        // PUT api/<FacturaController>/5
        [HttpPut("{id}")]
        public void Put(String id, [FromBody] Factura factura)
        {
            id = factura.IdFactura;
            contextBD.Entry(factura).State = EntityState.Modified;
            contextBD.SaveChanges();
        }


        // DELETE api/<FacturaController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(String id)
        {
            if (contextBD.Factura == null)
            {
                return NotFound();
            }

            Factura factura = contextBD.Factura.Find(id);
            if (factura == null)
            {
                return NotFound();
            }

            contextBD.Factura.Remove(factura);
            contextBD.SaveChanges();
            return Ok();
        }
    }
}

