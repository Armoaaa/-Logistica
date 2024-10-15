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
    public class TipoDNIController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TipoDNIController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoDNI>>> ObtenerTiposDNI()
        {
            return await _context.TiposDNI.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TipoDNI>> ObtenerTipoDNI(int id)
        {
            var tipoDNI = await _context.TiposDNI.FindAsync(id);
            if (tipoDNI == null)
            {
                return NotFound();
            }
            return tipoDNI;
        }

        [HttpPost]
        public async Task<ActionResult<TipoDNI>> CrearTipoDNI(TipoDNI tipoDNI)
        {
            _context.TiposDNI.Add(tipoDNI);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(ObtenerTipoDNI), new { id = tipoDNI.IdTipoDni }, tipoDNI);
        }

        [HttpPost("masivo")]
        public async Task<ActionResult<IEnumerable<TipoDNI>>> CrearMultiplesTiposDNI(IEnumerable<TipoDNI> tiposDNI)
        {
            _context.TiposDNI.AddRange(tiposDNI);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(ObtenerTiposDNI), tiposDNI);
        }
    }
}
