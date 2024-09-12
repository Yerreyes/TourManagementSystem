using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoDos.APIRest.Datos;
using ProyectoDos.APIRest.Modelos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProyectoDos.APIRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TourController : ControllerBase
    {
        
        public TourController( ConexionBDcontext contextBD)
        {
            this.contextBD = contextBD;
        }
        private readonly ConexionBDcontext contextBD;

        // GET: api/<TourController>
        [HttpGet]
        public List<Tour> listar()
        {
            List<Tour> laLista;
            laLista = contextBD.Tour.ToList();
            return laLista;
        }

        // GET api/<TourController>/5
        [HttpGet("{id}")]
        public Tour ObtenerTour(String id)
        {
            Tour tour = contextBD.Tour.Find(id);
            return tour;
        }

        // POST api/<TourController>
        [HttpPost]
        public IActionResult CrearTour([FromBody] Tour tour)
        {
            contextBD.Tour.Add(tour);
            contextBD.SaveChanges();
            return Ok(tour);
        }

        // PUT api/<TourController>/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] Tour tour)
        {
            id = tour.Id;
            contextBD.Entry(tour).State = EntityState.Modified;
            contextBD.SaveChanges();
        }

        // DELETE api/<TourController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            if (contextBD.Tour == null)
            {
                return NotFound();
            }

            Tour tour = contextBD.Tour.Find(id);
            if (tour == null)
            {
                return NotFound();
            }
            contextBD.Tour.Remove(tour);
            contextBD.SaveChanges();
            return Ok();
        }
    }
}
