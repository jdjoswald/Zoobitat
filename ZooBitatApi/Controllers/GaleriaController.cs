using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZooBitatApi.Models;

namespace ZooBitatApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GaleriaController : ControllerBase
    {
        private readonly AplicationDbContext _context;

        public GaleriaController(AplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/galeria/idespecie/{idEspecie}
        [HttpGet("idespecie/{idEspecie}")]
        public async Task<ActionResult<IEnumerable<Galeria>>> GetGaleriaPorIdEspecie(int idEspecie)
        {
            var galerias = await _context.Galerias
                .Where(g => g.IdEspecie == idEspecie)
                .ToListAsync();

            if (galerias == null)
            {
                return NotFound();
            }

            return galerias;
        }

        [HttpPost]
        public async Task<ActionResult<Galeria>> AgregarGaleria(Galeria galeria)
        {
            var especie = await _context.Especies.FindAsync(galeria.IdEspecie);

            if (especie == null)
            {
                return NotFound("La especie especificada no existe.");
            }

            galeria.Especie = especie;

            _context.Galerias.Add(galeria);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetGaleriaPorIdEspecie), new { idEspecie = galeria.IdEspecie }, galeria);
        }

        // DELETE: api/galeria/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Galeria>> EliminarGaleria(int id)
        {
            var galeria = await _context.Galerias.FindAsync(id);

            if (galeria == null)
            {
                return NotFound();
            }

            _context.Galerias.Remove(galeria);
            await _context.SaveChangesAsync();

            return galeria;
        }
    }
}
