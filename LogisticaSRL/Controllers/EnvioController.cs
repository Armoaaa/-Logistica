using Microsoft.AspNetCore.Mvc;
using LogisticaSRL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LogisticaSRL.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnvioController : ControllerBase
    {
        // Endpoints de Central
        [HttpGet("centrales")]
        public async Task<ActionResult<IEnumerable<Central>>> ObtenerCentrales()
        {
            // Implementación
        }

        [HttpGet("centrales/{id}")]
        public async Task<ActionResult<Central>> ObtenerCentral(int id)
        {
            // Implementación
        }

        [HttpPost("centrales")]
        public async Task<ActionResult<Central>> CrearCentral(Central central)
        {
            // Implementación
        }

        [HttpPost("centrales/masivo")]
        public async Task<ActionResult<IEnumerable<Central>>> CrearMultiplesCentrales(IEnumerable<Central> centrales)
        {
            // Implementación
        }

        // Endpoints de TipoDNI
        [HttpGet("tiposdni")]
        public async Task<ActionResult<IEnumerable<TipoDNI>>> ObtenerTiposDNI()
        {
            // Implementación
        }

        [HttpGet("tiposdni/{id}")]
        public async Task<ActionResult<TipoDNI>> ObtenerTipoDNI(int id)
        {
            // Implementación
        }

        [HttpPost("tiposdni")]
        public async Task<ActionResult<TipoDNI>> CrearTipoDNI(TipoDNI tipoDNI)
        {
            // Implementación
        }

        [HttpPost("tiposdni/masivo")]
        public async Task<ActionResult<IEnumerable<TipoDNI>>> CrearMultiplesTiposDNI(IEnumerable<TipoDNI> tiposDNI)
        {
            // Implementación
        }

        // Endpoints de Envio
        [HttpGet("envios")]
        public async Task<ActionResult<IEnumerable<Envio>>> ObtenerEnvios()
        {
            // Implementación
        }

        [HttpGet("envios/{numeroSeguimiento}")]
        public async Task<ActionResult<Envio>> ObtenerEnvio(int numeroSeguimiento)
        {
            // Implementación
        }

        [HttpPost("envios")]
        public async Task<ActionResult<Envio>> CrearEnvio(Envio envio)
        {
            // Implementación
        }

        [HttpPost("envios/masivo")]
        public async Task<ActionResult<IEnumerable<Envio>>> CrearMultiplesEnvios(IEnumerable<Envio> envios)
        {
            // Implementación
        }

        // Endpoints de HistorialEnvio
        [HttpGet("historialenvios")]
        public async Task<ActionResult<IEnumerable<HistorialEnvio>>> ObtenerHistorialEnvios()
        {
            // Implementación
        }

        [HttpGet("historialenvios/{id}")]
        public async Task<ActionResult<HistorialEnvio>> ObtenerHistorialEnvio(int id)
        {
            // Implementación
        }

        [HttpPost("historialenvios")]
        public async Task<ActionResult<HistorialEnvio>> CrearHistorialEnvio(HistorialEnvio historialEnvio)
        {
            // Implementación
        }

        [HttpPost("historialenvios/masivo")]
        public async Task<ActionResult<IEnumerable<HistorialEnvio>>> CrearMultiplesHistorialEnvios(IEnumerable<HistorialEnvio> historialEnvios)
        {
            // Implementación
        }

        // Endpoints de IntentoEntrega
        [HttpGet("intentosentrega")]
        public async Task<ActionResult<IEnumerable<IntentoEntrega>>> ObtenerIntentosEntrega()
        {
            // Implementación
        }

        [HttpGet("intentosentrega/{id}")]
        public async Task<ActionResult<IntentoEntrega>> ObtenerIntentoEntrega(int id)
        {
            // Implementación
        }

        [HttpPost("intentosentrega")]
        public async Task<ActionResult<IntentoEntrega>> CrearIntentoEntrega(IntentoEntrega intentoEntrega)
        {
            // Implementación
        }

        [HttpPost("intentosentrega/masivo")]
        public async Task<ActionResult<IEnumerable<IntentoEntrega>>> CrearMultiplesIntentosEntrega(IEnumerable<IntentoEntrega> intentosEntrega)
        {
            // Implementación
        }

        // Endpoints de Persona
        [HttpGet("personas")]
        public async Task<ActionResult<IEnumerable<Persona>>> ObtenerPersonas()
        {
            // Implementación
        }

        [HttpGet("personas/{id}")]
        public async Task<ActionResult<Persona>> ObtenerPersona(int id)
        {
            // Implementación
        }

        [HttpPost("personas")]
        public async Task<ActionResult<Persona>> CrearPersona(Persona persona)
        {
            // Implementación
        }

        [HttpPost("personas/masivo")]
        public async Task<ActionResult<IEnumerable<Persona>>> CrearMultiplesPersonas(IEnumerable<Persona> personas)
        {
            // Implementación
        }

        // Endpoints de Sucursal
        [HttpGet("sucursales")]
        public async Task<ActionResult<IEnumerable<Sucursal>>> ObtenerSucursales()
        {
            // Implementación
        }

        [HttpGet("sucursales/{id}")]
        public async Task<ActionResult<Sucursal>> ObtenerSucursal(int id)
        {
            // Implementación
        }

        [HttpPost("sucursales")]
        public async Task<ActionResult<Sucursal>> CrearSucursal(Sucursal sucursal)
        {
            // Implementación
        }

        [HttpPost("sucursales/masivo")]
        public async Task<ActionResult<IEnumerable<Sucursal>>> CrearMultiplesSucursales(IEnumerable<Sucursal> sucursales)
        {
            // Implementación
        }
    }
}

