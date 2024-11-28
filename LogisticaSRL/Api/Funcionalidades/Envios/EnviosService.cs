using Biblioteca.Dominio;
using Api.Persistencia;
using Microsoft.EntityFrameworkCore;

namespace Api.Funcionalidades.Envios
{
    public class EnviosService
    {
        private readonly GestionPedidoDbContext _context;

        public EnviosService(GestionPedidoDbContext context)
        {
            _context = context;
        }

        public async Task<List<EnviosQueryDto>> ObtenerEnviosAsync()
        {
            return await _context.Envios
                .Include(e => e.personaEmisora)
                .Include(e => e.personaReceptora)
                .Include(e => e.sucursalDespacho)
                .Include(e => e.sucursalDestino)
                .Include(e => e.centralDespacho)
                .Include(e => e.centralDestino)
                .Include(e => e.Historiales)
                .Select(e => new EnviosQueryDto
                {
                    NumeroSeguimiento = e.NumeroSeguimiento,
                    IdPersonaEmisora = e.IdPersonaEmisora,
                    personaEmisora = e.personaEmisora,
                    IdPersonaReceptora = e.IdPersonaReceptora,
                    personaReceptora = e.personaReceptora,
                    SucursalDespachoId = e.SucursalDespachoId,
                    sucursalDespacho = e.sucursalDespacho,
                    SucursalDestinoId = e.SucursalDestinoId,
                    sucursalDestino = e.sucursalDestino,
                    CentralDespachoId = e.CentralDespachoId,
                    centralDespacho = e.centralDespacho,
                    CentralDestinoId = e.CentralDestinoId,
                    centralDestino = e.centralDestino,
                    estadoEnvio = e.estadoEnvio,
                    Dimensiones = e.Dimensiones,
                    Peso = e.Peso,
                    FechaCreacion = e.FechaCreacion,
                    FechaActualizacion = e.FechaActualizacion,
                    Historiales = e.Historiales
                }).ToListAsync();
        }

        public async Task<EnviosQueryDto> CrearEnvioAsync(EnviosCommandDto envioDto)
        {
            var envio = new Envio
            {
                IdPersonaEmisora = envioDto.IdPersonaEmisora,
                IdPersonaReceptora = envioDto.IdPersonaReceptora,
                SucursalDespachoId = envioDto.SucursalDespachoId,
                SucursalDestinoId = envioDto.SucursalDestinoId,
                CentralDespachoId = envioDto.CentralDespachoId,
                CentralDestinoId = envioDto.CentralDestinoId,
                estadoEnvio = EstadoEnvio.Creado,
                Dimensiones = envioDto.Dimensiones,
                Peso = envioDto.Peso,
                FechaCreacion = DateTime.UtcNow,
                FechaActualizacion = DateTime.UtcNow
            };

            _context.Envios.Add(envio);
            await _context.SaveChangesAsync();

            return await ObtenerEnvioPorIdAsync(envio.NumeroSeguimiento);
        }

        public async Task<EnviosQueryDto> ActualizarEnvioAsync(int numeroSeguimiento, EnviosCommandDto envioDto)
        {
            var envio = await _context.Envios.FindAsync(numeroSeguimiento);
            if (envio == null) return null;

            envio.IdPersonaEmisora = envioDto.IdPersonaEmisora;
            envio.IdPersonaReceptora = envioDto.IdPersonaReceptora;
            envio.SucursalDespachoId = envioDto.SucursalDespachoId;
            envio.SucursalDestinoId = envioDto.SucursalDestinoId;
            envio.CentralDespachoId = envioDto.CentralDespachoId;
            envio.CentralDestinoId = envioDto.CentralDestinoId;
            envio.Dimensiones = envioDto.Dimensiones;
            envio.Peso = envioDto.Peso;
            envio.FechaActualizacion = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return await ObtenerEnvioPorIdAsync(numeroSeguimiento);
        }

        public async Task<bool> EliminarEnvioAsync(int numeroSeguimiento)
        {
            var envio = await _context.Envios.FindAsync(numeroSeguimiento);
            if (envio == null) return false;

            _context.Envios.Remove(envio);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<EnviosQueryDto> ObtenerEnvioPorIdAsync(int numeroSeguimiento)
        {
            return await _context.Envios
                .Include(e => e.personaEmisora)
                .Include(e => e.personaReceptora)
                .Include(e => e.sucursalDespacho)
                .Include(e => e.sucursalDestino)
                .Include(e => e.centralDespacho)
                .Include(e => e.centralDestino)
                .Include(e => e.Historiales)
                .Where(e => e.NumeroSeguimiento == numeroSeguimiento)
                .Select(e => new EnviosQueryDto
                {
                    NumeroSeguimiento = e.NumeroSeguimiento,
                    IdPersonaEmisora = e.IdPersonaEmisora,
                    personaEmisora = e.personaEmisora,
                    IdPersonaReceptora = e.IdPersonaReceptora,
                    personaReceptora = e.personaReceptora,
                    SucursalDespachoId = e.SucursalDespachoId,
                    sucursalDespacho = e.sucursalDespacho,
                    SucursalDestinoId = e.SucursalDestinoId,
                    sucursalDestino = e.sucursalDestino,
                    CentralDespachoId = e.CentralDespachoId,
                    centralDespacho = e.centralDespacho,
                    CentralDestinoId = e.CentralDestinoId,
                    centralDestino = e.centralDestino,
                    estadoEnvio = e.estadoEnvio,
                    Dimensiones = e.Dimensiones,
                    Peso = e.Peso,
                    FechaCreacion = e.FechaCreacion,
                    FechaActualizacion = e.FechaActualizacion,
                    Historiales = e.Historiales
                })
                .FirstOrDefaultAsync();
        }
    }
}