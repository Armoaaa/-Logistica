using Microsoft.AspNetCore.Mvc;

namespace Api.Funcionalidades.IntentosEntrega
{
    public static class IntentoEntregaEndpoints
    {
        public static RouteGroupBuilder MapIntentoEntregaEndpoints(this RouteGroupBuilder group)
        {
            group.MapGet("/", async ([FromServices] IntentoEntregaService intentoService) =>
            {
                var intentos = await intentoService.ObtenerIntentosEntregaAsync();
                return Results.Ok(intentos);
            })
            .WithName("ObtenerIntentosEntrega")
            .WithTags("IntentosEntrega");

            group.MapGet("/{idIntento}", async ([FromServices] IntentoEntregaService intentoService, int idIntento) =>
            {
                var intento = await intentoService.ObtenerIntentoEntregaPorIdAsync(idIntento);
                if (intento == null) return Results.NotFound();
                return Results.Ok(intento);
            })
            .WithName("ObtenerIntentoEntregaPorId")
            .WithTags("IntentosEntrega");

            group.MapPost("/", async ([FromServices] IntentoEntregaService intentoService, [FromBody] IntentoEntregaCommandDto intentoDto) =>
            {
                var nuevoIntento = await intentoService.CrearIntentoEntregaAsync(intentoDto);
                return Results.Created($"/api/intentosentrega/{nuevoIntento.IdIntentoEntrega}", nuevoIntento);
            })
            .WithName("CrearIntentoEntrega")
            .WithTags("IntentosEntrega");

            return group;
        }
    }
}