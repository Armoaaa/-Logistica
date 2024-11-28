using Biblioteca.Dominio;
using Api.Persistencia;
using Microsoft.EntityFrameworkCore;

namespace Api.Funcionalidades.Personas
{
    public class PersonaService
    {
        private readonly GestionPedidoDbContext _context;

        public PersonaService(GestionPedidoDbContext context)
        {
            _context = context;
        }

        public async Task<List<PersonaQueryDto>> ObtenerPersonasAsync()
        {
            return await _context.Personas
                .Include(p => p.TipoDNI)
                .Include(p => p.domicilio)
                .Select(p => new PersonaQueryDto
                {
                    IdPersona = p.IdPersona,
                    TipoDNIId = p.TipoDNIId,
                    TipoDNI = p.TipoDNI,
                    DomicilioId = p.DomicilioId,
                    Domicilio = p.domicilio,
                    DNI = p.DNI,
                    PaisResidente = p.PaisResidente,
                    Nombre = p.Nombre,
                    Apellido = p.Apellido
                }).ToListAsync();
        }

        public async Task<PersonaQueryDto> CrearPersonaAsync(PersonaCommandDto personaDto)
        {
            var persona = new Persona
            {
                TipoDNIId = personaDto.TipoDNIId,
                DomicilioId = personaDto.DomicilioId,
                DNI = personaDto.DNI,
                PaisResidente = personaDto.PaisResidente,
                Nombre = personaDto.Nombre,
                Apellido = personaDto.Apellido
            };

            _context.Personas.Add(persona);
            await _context.SaveChangesAsync();

            return await ObtenerPersonaPorIdAsync(persona.IdPersona);
        }

        public async Task<PersonaQueryDto> ActualizarPersonaAsync(int idPersona, PersonaCommandDto personaDto)
        {
            var persona = await _context.Personas.FindAsync(idPersona);
            if (persona == null) return null;

            persona.TipoDNIId = personaDto.TipoDNIId;
            persona.DomicilioId = personaDto.DomicilioId;
            persona.DNI = personaDto.DNI;
            persona.PaisResidente = personaDto.PaisResidente;
            persona.Nombre = personaDto.Nombre;
            persona.Apellido = personaDto.Apellido;

            await _context.SaveChangesAsync();

            return await ObtenerPersonaPorIdAsync(persona.IdPersona);
        }

        public async Task<bool> EliminarPersonaAsync(int idPersona)
        {
            var persona = await _context.Personas.FindAsync(idPersona);
            if (persona == null) return false;

            _context.Personas.Remove(persona);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<PersonaQueryDto> ObtenerPersonaPorIdAsync(int idPersona)
        {
            var persona = await _context.Personas
                .Include(p => p.TipoDNI)
                .Include(p => p.domicilio)
                .FirstOrDefaultAsync(p => p.IdPersona == idPersona);
            if (persona == null) return null;

            return new PersonaQueryDto
            {
                IdPersona = persona.IdPersona,
                TipoDNIId = persona.TipoDNIId,
                TipoDNI = persona.TipoDNI,
                DomicilioId = persona.DomicilioId,
                Domicilio = persona.domicilio,
                DNI = persona.DNI,
                PaisResidente = persona.PaisResidente,
                Nombre = persona.Nombre,
                Apellido = persona.Apellido
            };
        }
    }
}