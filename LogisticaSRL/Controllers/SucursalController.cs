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
    public class SucursalController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SucursalController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sucursal>>> ObtenerSucursales()
        {
            return await _context.Sucursales.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Sucursal>> ObtenerSucursal(int id)
        {
            var sucursal = await _context.Sucursales.FindAsync(id);
            if (sucursal == null)
            {
                return NotFound();
            }
            return sucursal;
        }

        [HttpPost]
        public async Task<ActionResult<Sucursal>> CrearSucursal(Sucursal sucursal)
        {
            _context.Sucursales.Add(sucursal);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(ObtenerSucursal), new { id = sucursal.IdSucursal }, sucursal);
        }

        [HttpPost("masivo")]
        public async Task<ActionResult<IEnumerable<Sucursal>>> CrearMultiplesSucursales(IEnumerable<Sucursal> sucursales)
        {
            _context.Sucursales.AddRange(sucursales);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(ObtenerSucursales), sucursales);
        }
    }
}
