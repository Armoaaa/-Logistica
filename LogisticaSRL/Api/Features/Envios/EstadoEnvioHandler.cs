using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.Persistencia;
using Biblioteca.Dominio;

namespace Api.Features.Envios
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstadoEnvioHandler : ControllerBase
    {
        private readonly GestionPedidoDbContext _context;

        public EstadoEnvioHandler(GestionPedidoDbContext context)
        {
            _context = context;
        }

        [HttpGet("{numeroSeguimiento}")]
        public async Task<IActionResult> ObtenerEstadoEnvio(int numeroSeguimiento)
        {
            var envio = await _context.Envios
                .Include(e => e.Historiales)
                .FirstOrDefaultAsync(e => e.NumeroSeguimiento == numeroSeguimiento);

            if (envio == null)
            {
                return NotFound();
            }

            var estadoActual = envio.estadoEnvio;
            return Ok(estadoActual);
        }
    }
} 