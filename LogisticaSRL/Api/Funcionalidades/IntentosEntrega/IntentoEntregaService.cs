using Api.Persistencia;
using Biblioteca.Dominio;
using Microsoft.EntityFrameworkCore;

namespace Api.Funcionalidades.IntentosEntrega
{
    public class IntentoEntregaService
    {
        private readonly GestionPedidoDbContext _context;

        public IntentoEntregaService(GestionPedidoDbContext context)
        {
            _context = context;
        }

        public async Task<List<IntentoEntregaQueryDto>> ObtenerIntentosEntregaAsync()
        {
            return await _context.IntentosEntrega
                .Include(i => i.Envio)
                .Include(i => i.sucursal)
                .Select(i => new IntentoEntregaQueryDto
                {
                    IdIntentoEntrega = i.IdIntentoEntrega,
                    NumeroSeguimiento = i.NumeroSeguimiento,
                    Envio = i.Envio,
                    SucursalId = i.SucursalId,
                    sucursal = i.sucursal,
                    NumeroIntento = i.NumeroIntento,
                    Entregado = i.Entregado,
                    FechaIntento = i.FechaIntento,
                    FechaCreacion = i.FechaCreacion
                }).ToListAsync();
        }

        public async Task<IntentoEntregaQueryDto> CrearIntentoEntregaAsync(IntentoEntregaCommandDto intentoDto)
        {
            var ultimoIntento = await _context.IntentosEntrega
                .Where(i => i.NumeroSeguimiento == intentoDto.NumeroSeguimiento)
                .OrderByDescending(i => i.NumeroIntento)
                .FirstOrDefaultAsync();

            var numeroIntento = (ultimoIntento?.NumeroIntento ?? 0) + 1;

            var intento = new IntentoEntrega
            {
                NumeroSeguimiento = intentoDto.NumeroSeguimiento,
                SucursalId = intentoDto.SucursalId,
                NumeroIntento = numeroIntento,
                Entregado = intentoDto.Entregado,
                FechaIntento = DateTime.UtcNow,
                FechaCreacion = DateTime.UtcNow
            };

            _context.IntentosEntrega.Add(intento);
            await _context.SaveChangesAsync();

            return await ObtenerIntentoEntregaPorIdAsync(intento.IdIntentoEntrega);
        }

        public async Task<IntentoEntregaQueryDto> ObtenerIntentoEntregaPorIdAsync(int idIntento)
        {
            return await _context.IntentosEntrega
                .Include(i => i.Envio)
                .Include(i => i.sucursal)
                .Where(i => i.IdIntentoEntrega == idIntento)
                .Select(i => new IntentoEntregaQueryDto
                {
                    IdIntentoEntrega = i.IdIntentoEntrega,
                    NumeroSeguimiento = i.NumeroSeguimiento,
                    Envio = i.Envio,
                    SucursalId = i.SucursalId,
                    sucursal = i.sucursal,
                    NumeroIntento = i.NumeroIntento,
                    Entregado = i.Entregado,
                    FechaIntento = i.FechaIntento,
                    FechaCreacion = i.FechaCreacion
                }).FirstOrDefaultAsync();
        }
    }
}