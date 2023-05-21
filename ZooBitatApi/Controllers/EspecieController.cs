using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZooBitatApi.Models;

namespace ZooBitatApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspecieController : ControllerBase
    {
        private readonly AplicationDbContext _context;

        public EspecieController(AplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Especie
        [HttpGet]
        [EnableCors("CorsPolicy")]
        public ActionResult<IEnumerable<Especie>> GetEspecies()
        {
            return _context.Especies;
        }

        // GET: api/Especie/5
        [HttpGet("{id}")]
        [EnableCors("CorsPolicy")]
        public ActionResult<Especie> GetEspecieById(int id)
        {
            var especie = _context.Especies.Find(id);

            if (especie == null)
            {
                return NotFound();
            }

            return especie;
        }

        // POST: api/Especie
        [HttpPost]
        [EnableCors("CorsPolicy")]
        public ActionResult<Especie> CreateEspecie(Especie especie)
        {
            _context.Especies.Add(especie);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetEspecieById), new { id = especie.IdEspecie }, especie);
        }

        // PUT: api/Especie/5
        [HttpPut("{id}")]
        [EnableCors("CorsPolicy")]
        public IActionResult UpdateEspecie(int id, Especie especie)
        {
            if (id != especie.IdEspecie)
            {
                return BadRequest();
            }

            _context.Entry(especie).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/Especie/5
        [HttpDelete("{id}")]
        [EnableCors("CorsPolicy")]
        public IActionResult DeleteEspecie(int id)
        {
            var especie = _context.Especies.Find(id);

            if (especie == null)
            {
                return NotFound();
            }

            _context.Especies.Remove(especie);
            _context.SaveChanges();

            return NoContent();
        }
    }
}

