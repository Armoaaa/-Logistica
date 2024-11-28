using Api.Persistencia;
using Biblioteca.Dominio;
using Microsoft.EntityFrameworkCore;

namespace Api.Funcionalidades.Centrales
{
    public class CentralService
    {
        private readonly GestionPedidoDbContext _context;

        public CentralService(GestionPedidoDbContext context)
        {
            _context = context;
        }

        public async Task<List<CentralQueryDto>> ObtenerCentralesAsync()
        {
            return await _context.Centrales
                .Include(c => c.domicilio)
                .Include(c => c.Sucursales)
                .Select(c => new CentralQueryDto
                {
                    IdCentral = c.IdCentral,
                    Nombre = c.Nombre,
                    DomicilioId = c.DomicilioId,
                    domicilio = c.domicilio,
                    Sucursales = c.Sucursales
                }).ToListAsync();
        }

        public async Task<CentralQueryDto> CrearCentralAsync(CentralCommandDto centralDto)
        {
            var central = new Central
            {
                Nombre = centralDto.Nombre,
                DomicilioId = centralDto.DomicilioId
            };

            _context.Centrales.Add(central);
            await _context.SaveChangesAsync();

            return await ObtenerCentralPorIdAsync(central.IdCentral);
        }

        public async Task<CentralQueryDto> ActualizarCentralAsync(int idCentral, CentralCommandDto centralDto)
        {
            var central = await _context.Centrales.FindAsync(idCentral);
            if (central == null) return null;

            central.Nombre = centralDto.Nombre;
            central.DomicilioId = centralDto.DomicilioId;

            await _context.SaveChangesAsync();
            return await ObtenerCentralPorIdAsync(idCentral);
        }

        public async Task<bool> EliminarCentralAsync(int idCentral)
        {
            var central = await _context.Centrales.FindAsync(idCentral);
            if (central == null) return false;

            _context.Centrales.Remove(central);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<CentralQueryDto> ObtenerCentralPorIdAsync(int idCentral)
        {
            return await _context.Centrales
                .Include(c => c.domicilio)
                .Include(c => c.Sucursales)
                .Where(c => c.IdCentral == idCentral)
                .Select(c => new CentralQueryDto
                {
                    IdCentral = c.IdCentral,
                    Nombre = c.Nombre,
                    DomicilioId = c.DomicilioId,
                    domicilio = c.domicilio,
                    Sucursales = c.Sucursales
                }).FirstOrDefaultAsync();
        }
    }
} 