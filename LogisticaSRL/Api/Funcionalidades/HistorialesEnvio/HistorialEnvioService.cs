using Api.Persistencia;
using Biblioteca.Dominio;
using Microsoft.EntityFrameworkCore;

namespace Api.Funcionalidades.HistorialesEnvio
{
    public class HistorialEnvioService
    {
        private readonly GestionPedidoDbContext _context;

        public HistorialEnvioService(GestionPedidoDbContext context)
        {
            _context = context;
        }

        public async Task<List<HistorialEnvioQueryDto>> ObtenerHistorialesEnvioAsync()
        {
            return await _context.HistorialesEnvio
                .Include(h => h.envio)
                .Include(h => h.sucursal)
                .Select(h => new HistorialEnvioQueryDto
                {
                    IdHistorialEnvio = h.IdHistorialEnvio,
                    NumeroSeguimiento = h.NumeroSeguimiento,
                    envio = h.envio,
                    SucursalId = h.SucursalId,
                    sucursal = h.sucursal,
                    estadoEnvio = h.estadoEnvio,
                    FechaCambio = h.FechaCambio,
                    FechaCreacion = h.FechaCreacion
                }).ToListAsync();
        }

        public async Task<HistorialEnvioQueryDto> CrearHistorialEnvioAsync(HistorialEnvioCommandDto historialDto)
        {
            var historial = new HistorialEnvio
            {
                NumeroSeguimiento = historialDto.NumeroSeguimiento,
                SucursalId = historialDto.SucursalId,
                estadoEnvio = historialDto.estadoEnvio,
                FechaCambio = DateTime.UtcNow,
                FechaCreacion = DateTime.UtcNow
            };

            _context.HistorialesEnvio.Add(historial);
            await _context.SaveChangesAsync();

            return await ObtenerHistorialEnvioPorIdAsync(historial.IdHistorialEnvio);
        }

        public async Task<HistorialEnvioQueryDto> ObtenerHistorialEnvioPorIdAsync(int idHistorial)
        {
            return await _context.HistorialesEnvio
                .Include(h => h.envio)
                .Include(h => h.sucursal)
                .Where(h => h.IdHistorialEnvio == idHistorial)
                .Select(h => new HistorialEnvioQueryDto
                {
                    IdHistorialEnvio = h.IdHistorialEnvio,
                    NumeroSeguimiento = h.NumeroSeguimiento,
                    envio = h.envio,
                    SucursalId = h.SucursalId,
                    sucursal = h.sucursal,
                    estadoEnvio = h.estadoEnvio,
                    FechaCambio = h.FechaCambio,
                    FechaCreacion = h.FechaCreacion
                }).FirstOrDefaultAsync();
        }

        public async Task<bool> EliminarHistorialEnvioAsync(int idHistorial)
        {
            var historial = await _context.HistorialesEnvio.FindAsync(idHistorial);
            if (historial == null) return false;

            _context.HistorialesEnvio.Remove(historial);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}