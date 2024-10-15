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
    public class PersonaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PersonaController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Persona>>> ObtenerPersonas()
        {
            return await _context.Personas.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Persona>> ObtenerPersona(int id)
        {
            var persona = await _context.Personas.FindAsync(id);
            if (persona == null)
            {
                return NotFound();
            }
            return persona;
        }

        [HttpPost]
        public async Task<ActionResult<Persona>> CrearPersona(Persona persona)
        {
            _context.Personas.Add(persona);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(ObtenerPersona), new { id = persona.IdPersona }, persona);
        }

        [HttpPost("masivo")]
        public async Task<ActionResult<IEnumerable<Persona>>> CrearMultiplesPersonas(IEnumerable<Persona> personas)
        {
            _context.Personas.AddRange(personas);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(ObtenerPersonas), personas);
        }
    }
}
