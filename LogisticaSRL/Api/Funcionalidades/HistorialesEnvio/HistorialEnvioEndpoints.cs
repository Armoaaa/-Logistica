using Microsoft.AspNetCore.Mvc;

namespace Api.Funcionalidades.HistorialesEnvio
{
    public static class HistorialEnvioEndpoints
    {
        public static RouteGroupBuilder MapHistorialEnvioEndpoints(this RouteGroupBuilder group)
        {
            group.MapGet("/", async ([FromServices] HistorialEnvioService historialService) =>
            {
                var historiales = await historialService.ObtenerHistorialesEnvioAsync();
                return Results.Ok(historiales);
            })
            .WithName("ObtenerHistorialesEnvio")
            .WithTags("HistorialesEnvio");

            group.MapGet("/{idHistorial}", async ([FromServices] HistorialEnvioService historialService, int idHistorial) =>
            {
                var historial = await historialService.ObtenerHistorialEnvioPorIdAsync(idHistorial);
                if (historial == null) return Results.NotFound();
                return Results.Ok(historial);
            })
            .WithName("ObtenerHistorialEnvioPorId")
            .WithTags("HistorialesEnvio");

            group.MapPost("/", async ([FromServices] HistorialEnvioService historialService, [FromBody] HistorialEnvioCommandDto historialDto) =>
            {
                var nuevoHistorial = await historialService.CrearHistorialEnvioAsync(historialDto);
                return Results.Created($"/api/historialesenvio/{nuevoHistorial.IdHistorialEnvio}", nuevoHistorial);
            })
            .WithName("CrearHistorialEnvio")
            .WithTags("HistorialesEnvio");

            group.MapDelete("/{idHistorial}", async ([FromServices] HistorialEnvioService historialService, int idHistorial) =>
            {
                var resultado = await historialService.EliminarHistorialEnvioAsync(idHistorial);
                if (!resultado) return Results.NotFound();
                return Results.NoContent();
            })
            .WithName("EliminarHistorialEnvio")
            .WithTags("HistorialesEnvio");

            return group;
        }
    }
}