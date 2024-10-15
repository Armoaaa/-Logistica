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
    public class IntentoEntregaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public IntentoEntregaController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<IntentoEntrega>>> ObtenerIntentosEntrega()
        {
            return await _context.IntentosEntrega.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IntentoEntrega>> ObtenerIntentoEntrega(int id)
        {
            var intentoEntrega = await _context.IntentosEntrega.FindAsync(id);
            if (intentoEntrega == null)
            {
                return NotFound();
            }
            return intentoEntrega;
        }

        [HttpPost]
        public async Task<ActionResult<IntentoEntrega>> CrearIntentoEntrega(IntentoEntrega intentoEntrega)
        {
            _context.IntentosEntrega.Add(intentoEntrega);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(ObtenerIntentoEntrega), new { id = intentoEntrega.IdIntentoEntrega }, intentoEntrega);
        }

        [HttpPost("masivo")]
        public async Task<ActionResult<IEnumerable<IntentoEntrega>>> CrearMultiplesIntentosEntrega(IEnumerable<IntentoEntrega> intentosEntrega)
        {
            _context.IntentosEntrega.AddRange(intentosEntrega);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(ObtenerIntentosEntrega), intentosEntrega);
        }
    }
}
