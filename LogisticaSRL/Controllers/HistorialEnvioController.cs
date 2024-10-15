using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LogisticaSRL.Models;
using LogisticaSRL.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LogisticaSRL.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HistorialEnvioController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public HistorialEnvioController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HistorialEnvio>>> ObtenerHistorialEnvios()
        {
            return await _context.HistorialEnvios.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HistorialEnvio>> ObtenerHistorialEnvio(int id)
        {
            var historialEnvio = await _context.HistorialEnvios.FindAsync(id);
            if (historialEnvio == null)
            {
                return NotFound();
            }
            return historialEnvio;
        }

        [HttpPost]
        public async Task<ActionResult<HistorialEnvio>> CrearHistorialEnvio(HistorialEnvio historialEnvio)
        {
            _context.HistorialEnvios.Add(historialEnvio);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(ObtenerHistorialEnvio), new { id = historialEnvio.IdHistorialEnvio }, historialEnvio);
        }

        [HttpPost("masivo")]
        public async Task<ActionResult<IEnumerable<HistorialEnvio>>> CrearMultiplesHistorialEnvios(IEnumerable<HistorialEnvio> historialEnvios)
        {
            _context.HistorialEnvios.AddRange(historialEnvios);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(ObtenerHistorialEnvios), historialEnvios);
        }
    }
}
