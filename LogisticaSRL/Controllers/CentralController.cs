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
    public class CentralController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CentralController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Central>>> ObtenerCentrales()
        {
            return await _context.Centrales.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Central>> ObtenerCentral(int id)
        {
            var central = await _context.Centrales.FindAsync(id);
            if (central == null)
            {
                return NotFound();
            }
            return central;
        }

        [HttpPost]
        public async Task<ActionResult<Central>> CrearCentral(Central central)
        {
            _context.Centrales.Add(central);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(ObtenerCentral), new { id = central.IdCentral }, central);
        }

        [HttpPost("masivo")]
        public async Task<ActionResult<IEnumerable<Central>>> CrearMultiplesCentrales(IEnumerable<Central> centrales)
        {
            _context.Centrales.AddRange(centrales);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(ObtenerCentrales), centrales);
        }
    }
}
