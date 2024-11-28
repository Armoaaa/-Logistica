using Biblioteca.Dominio;
using Microsoft.EntityFrameworkCore;
using Api.Persistencia;

namespace Api.Funcionalidades.Domicilios
{
    public class DomicilioService
    {
        private readonly GestionPedidoDbContext _context;

        public DomicilioService(GestionPedidoDbContext context)
        {
            _context = context;
        }

        public async Task<List<DomicilioQueryDto>> ObtenerDomiciliosAsync()
        {
            return await _context.Domicilios
                .Select(d => new DomicilioQueryDto
                {
                    IdDomicilio = d.IdDomicilio,
                    Pais = d.Pais,
                    Ciudad = d.Ciudad,
                    Calle = d.Calle,
                    Numero = d.Numero,
                    CodigoPostal = d.CodigoPostal
                }).ToListAsync();
        }

        public async Task<DomicilioQueryDto> CrearDomicilioAsync(DomicilioCommandDto domicilioDto)
        {
            var domicilio = new Domicilio
            {
                Pais = domicilioDto.Pais,
                Ciudad = domicilioDto.Ciudad,
                Calle = domicilioDto.Calle,
                Numero = domicilioDto.Numero,
                CodigoPostal = domicilioDto.CodigoPostal
            };

            _context.Domicilios.Add(domicilio);
            await _context.SaveChangesAsync();

            return await ObtenerDomicilioPorIdAsync(domicilio.IdDomicilio);
        }

        public async Task<DomicilioQueryDto> ActualizarDomicilioAsync(int idDomicilio, DomicilioCommandDto domicilioDto)
        {
            var domicilio = await _context.Domicilios.FindAsync(idDomicilio);
            if (domicilio == null) return null;

            domicilio.Pais = domicilioDto.Pais;
            domicilio.Ciudad = domicilioDto.Ciudad;
            domicilio.Calle = domicilioDto.Calle;
            domicilio.Numero = domicilioDto.Numero;
            domicilio.CodigoPostal = domicilioDto.CodigoPostal;

            await _context.SaveChangesAsync();

            return new DomicilioQueryDto
            {
                IdDomicilio = domicilio.IdDomicilio,
                Pais = domicilio.Pais,
                Ciudad = domicilio.Ciudad,
                Calle = domicilio.Calle,
                Numero = domicilio.Numero,
                CodigoPostal = domicilio.CodigoPostal
            };
        }

        public async Task<bool> EliminarDomicilioAsync(int idDomicilio)
        {
            var domicilio = await _context.Domicilios.FindAsync(idDomicilio);
            if (domicilio == null) return false;

            _context.Domicilios.Remove(domicilio);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<DomicilioQueryDto> ObtenerDomicilioPorIdAsync(int idDomicilio)
        {
            var domicilio = await _context.Domicilios.FindAsync(idDomicilio);
            if (domicilio == null) return null;

            return new DomicilioQueryDto
            {
                IdDomicilio = domicilio.IdDomicilio,
                Pais = domicilio.Pais,
                Ciudad = domicilio.Ciudad,
                Calle = domicilio.Calle,
                Numero = domicilio.Numero,
                CodigoPostal = domicilio.CodigoPostal
            };
        }
    }
}