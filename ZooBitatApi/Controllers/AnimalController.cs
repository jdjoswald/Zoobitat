using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZooBitatApi.Models;

namespace ZooBitatApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private readonly AplicationDbContext _context;

        public AnimalController(AplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [EnableCors("CorsPolicy")]
        public async Task<ActionResult<IEnumerable<Animal>>> GetAnimals()
        {
            return await _context.Animales.ToListAsync();
        }

        [HttpGet("{id}")]
        [EnableCors("CorsPolicy")]
        public async Task<ActionResult<Animal>> GetAnimal(int id)
        {
            var animal = await _context.Animales.FindAsync(id);

            if (animal == null)
            {
                return NotFound();
            }

            return animal;
        }

        [HttpPost]
        [EnableCors("CorsPolicy")]
        public async Task<ActionResult<Animal>> CreateAnimal(Animal animal)
        {
            var especie = await _context.Especies.FindAsync(animal.IdEspecie);
            if (especie == null)
            {
                // La especie no existe, devolver un error o realizar alguna acción apropiada
                return NotFound("La especie especificada no existe.");
            }

            // Asignar la especie existente al animal
            animal.Especie = especie;

            _context.Animales.Add(animal);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAnimal", new { id = animal.IdAnimal }, animal);

        }

        [HttpPut("{id}")]
        [EnableCors("CorsPolicy")]
        public async Task<IActionResult> UpdateAnimal(int id, Animal animal)
        {
            if (id != animal.IdAnimal)
            {
                return BadRequest();
            }

            _context.Entry(animal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnimalExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        [EnableCors("CorsPolicy")]
        public async Task<IActionResult> DeleteAnimal(int id)
        {
            var animal = await _context.Animales.FindAsync(id);
            if (animal == null)
            {
                return NotFound();
            }

            _context.Animales.Remove(animal);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AnimalExists(int id)
        {
            return _context.Animales.Any(a => a.IdAnimal == id);
        }
    }
}
