using Microsoft.AspNetCore.Mvc;

namespace Api.Funcionalidades.Envios
{
    public static class EnviosEndpoints
    {
        public static RouteGroupBuilder MapEnviosEndpoints(this RouteGroupBuilder group)
        {
            group.MapGet("/", async ([FromServices] EnviosService enviosService) =>
            {
                var envios = await enviosService.ObtenerEnviosAsync();
                return Results.Ok(envios);
            })
            .WithName("ObtenerEnvios")
            .WithTags("Envios");

            group.MapGet("/{numeroSeguimiento}", async ([FromServices] EnviosService enviosService, int numeroSeguimiento) =>
            {
                var envio = await enviosService.ObtenerEnvioPorIdAsync(numeroSeguimiento);
                if (envio == null) return Results.NotFound();
                return Results.Ok(envio);
            })
            .WithName("ObtenerEnvioPorId")
            .WithTags("Envios");

            group.MapPost("/", async ([FromServices] EnviosService enviosService, [FromBody] EnviosCommandDto envioDto) =>
            {
                var nuevoEnvio = await enviosService.CrearEnvioAsync(envioDto);
                return Results.Created($"/api/envios/{nuevoEnvio.NumeroSeguimiento}", nuevoEnvio);
            })
            .WithName("CrearEnvio")
            .WithTags("Envios");

            group.MapPut("/{numeroSeguimiento}", async ([FromServices] EnviosService enviosService, int numeroSeguimiento, [FromBody] EnviosCommandDto envioDto) =>
            {
                var envio = await enviosService.ActualizarEnvioAsync(numeroSeguimiento, envioDto);
                if (envio == null) return Results.NotFound();
                return Results.Ok(envio);
            })
            .WithName("ActualizarEnvio")
            .WithTags("Envios");

            group.MapDelete("/{numeroSeguimiento}", async ([FromServices] EnviosService enviosService, int numeroSeguimiento) =>
            {
                var resultado = await enviosService.EliminarEnvioAsync(numeroSeguimiento);
                if (!resultado) return Results.NotFound();
                return Results.NoContent();
            })
            .WithName("EliminarEnvio")
            .WithTags("Envios");

            return group;
        }
    }
}