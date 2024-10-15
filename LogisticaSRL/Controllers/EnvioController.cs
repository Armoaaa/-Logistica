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
    public class EnvioController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EnvioController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Envio>>> ObtenerEnvios()
        {
            return await _context.Envios.ToListAsync();
        }

        [HttpGet("{numeroSeguimiento}")]
        public async Task<ActionResult<Envio>> ObtenerEnvio(int numeroSeguimiento)
        {
            var envio = await _context.Envios.FindAsync(numeroSeguimiento);
            if (envio == null)
            {
                return NotFound();
            }
            return envio;
        }

        [HttpPost]
        public async Task<ActionResult<Envio>> CrearEnvio(Envio envio)
        {
            _context.Envios.Add(envio);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(ObtenerEnvio), new { numeroSeguimiento = envio.NumeroSeguimiento }, envio);
        }

        [HttpPost("masivo")]
        public async Task<ActionResult<IEnumerable<Envio>>> CrearMultiplesEnvios(IEnumerable<Envio> envios)
        {
            _context.Envios.AddRange(envios);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(ObtenerEnvios), envios);
        }
    }
}
