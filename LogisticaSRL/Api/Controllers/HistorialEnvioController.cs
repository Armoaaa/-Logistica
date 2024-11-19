using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.Persistencia;
using Biblioteca.Dominio;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HistorialEnvioController : ControllerBase
    {
        private readonly GestionPedidoDbContext _context;

        public HistorialEnvioController(GestionPedidoDbContext context)
        {
            _context = context;
        }

        // GET: api/HistorialEnvio
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HistorialEnvio>>> GetHistoriales()
        {
            return await _context.HistorialesEnvio.ToListAsync();
        }

        // GET: api/HistorialEnvio/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HistorialEnvio>> GetHistorialEnvio(int id)
        {
            var historial = await _context.HistorialesEnvio.FindAsync(id);

            if (historial == null)
            {
                return NotFound();
            }

            return historial;
        }

        // POST: api/HistorialEnvio
        [HttpPost]
        public async Task<ActionResult<HistorialEnvio>> PostHistorialEnvio(HistorialEnvio historial)
        {
            _context.HistorialesEnvio.Add(historial);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetHistorialEnvio), new { id = historial.IdHistorialEnvio }, historial);
        }

        // DELETE: api/HistorialEnvio/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHistorialEnvio(int id)
        {
            var historial = await _context.HistorialesEnvio.FindAsync(id);
            if (historial == null)
            {
                return NotFound();
            }

            _context.HistorialesEnvio.Remove(historial);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
} 