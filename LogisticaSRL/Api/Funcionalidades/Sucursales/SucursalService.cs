using Api.Persistencia;
using Biblioteca.Dominio;
using Microsoft.EntityFrameworkCore;

namespace Api.Funcionalidades.Sucursales
{
    public class SucursalService
    {
        private readonly GestionPedidoDbContext _context;

        public SucursalService(GestionPedidoDbContext context)
        {
            _context = context;
        }

        public async Task<List<SucursalQueryDto>> ObtenerSucursalesAsync()
        {
            return await _context.Sucursales
                .Include(s => s.domicilio)
                .Include(s => s.Central)
                .Select(s => new SucursalQueryDto
                {
                    IdSucursal = s.IdSucursal,
                    NumeroS = s.NumeroS,
                    Nombre = s.Nombre,
                    DomicilioId = s.DomicilioId,
                    Domicilio = s.domicilio,
                    IdCentral = s.IdCentral,
                    Central = s.Central
                }).ToListAsync();
        }

        public async Task<SucursalQueryDto> CrearSucursalAsync(SucursalCommandDto sucursalDto)
        {
            var sucursal = new Sucursal
            {
                NumeroS = sucursalDto.NumeroS,
                Nombre = sucursalDto.Nombre,
                DomicilioId = sucursalDto.DomicilioId,
                IdCentral = sucursalDto.IdCentral
            };

            _context.Sucursales.Add(sucursal);
            await _context.SaveChangesAsync();

            return await ObtenerSucursalPorIdAsync(sucursal.IdSucursal);
        }

        public async Task<SucursalQueryDto> ActualizarSucursalAsync(int idSucursal, SucursalCommandDto sucursalDto)
        {
            var sucursal = await _context.Sucursales.FindAsync(idSucursal);
            if (sucursal == null) return null;

            sucursal.NumeroS = sucursalDto.NumeroS;
            sucursal.Nombre = sucursalDto.Nombre;
            sucursal.DomicilioId = sucursalDto.DomicilioId;
            sucursal.IdCentral = sucursalDto.IdCentral;

            await _context.SaveChangesAsync();
            return await ObtenerSucursalPorIdAsync(idSucursal);
        }

        public async Task<bool> EliminarSucursalAsync(int idSucursal)
        {
            var sucursal = await _context.Sucursales.FindAsync(idSucursal);
            if (sucursal == null) return false;

            _context.Sucursales.Remove(sucursal);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<SucursalQueryDto> ObtenerSucursalPorIdAsync(int idSucursal)
        {
            return await _context.Sucursales
                .Include(s => s.domicilio)
                .Include(s => s.Central)
                .Where(s => s.IdSucursal == idSucursal)
                .Select(s => new SucursalQueryDto
                {
                    IdSucursal = s.IdSucursal,
                    NumeroS = s.NumeroS,
                    Nombre = s.Nombre,
                    DomicilioId = s.DomicilioId,
                    Domicilio = s.domicilio,
                    IdCentral = s.IdCentral,
                    Central = s.Central
                }).FirstOrDefaultAsync();
        }
    }
}