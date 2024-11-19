using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.Persistencia;
using Biblioteca.Dominio;

namespace Api.Features.Envios
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnvioHandler : ControllerBase
    {
        private readonly GestionPedidoDbContext _context;

        public EnvioHandler(GestionPedidoDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CrearEnvio([FromBody] Envio nuevoEnvio)
        {
            _context.Envios.Add(nuevoEnvio);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(ObtenerEnvio), new { id = nuevoEnvio.NumeroSeguimiento }, nuevoEnvio);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerEnvio(int id)
        {
            var envio = await _context.Envios.FindAsync(id);
            if (envio == null)
            {
                return NotFound();
            }
            return Ok(envio);
        }

        // Otros métodos para actualizar y eliminar envíos
    }
} 