using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.Persistencia;
using Biblioteca.Dominio;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CentralesController : ControllerBase
    {
        private readonly GestionPedidoDbContext _context;

        public CentralesController(GestionPedidoDbContext context)
        {
            _context = context;
        }

        // GET: api/Centrales
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Central>>> GetCentrales()
        {
            return await _context.Centrales.ToListAsync();
        }

        // GET: api/Centrales/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Central>> GetCentral(int id)
        {
            var central = await _context.Centrales.FindAsync(id);

            if (central == null)
            {
                return NotFound();
            }

            return central;
        }

        // POST: api/Centrales
        [HttpPost]
        public async Task<ActionResult<Central>> PostCentral(Central central)
        {
            _context.Centrales.Add(central);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCentral), new { id = central.IdCentral  }, central);
        }

        // PUT: api/Centrales/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCentral(int id, Central central)
        {
            if (id != central.IdCentral)
            {
                return BadRequest();
            }

            _context.Entry(central).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }   
            catch (DbUpdateConcurrencyException)
            {
                if (!CentralExists(id))
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

        // DELETE: api/Centrales/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCentral(int id)
        {
            var central = await _context.Centrales.FindAsync(id);
            if (central == null)
            {
                return NotFound();
            }

            _context.Centrales.Remove(central);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CentralExists(int id)
        {
            return _context.Centrales.Any(e => e.IdCentral  == id);
        }
    }
} 