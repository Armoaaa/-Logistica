using Microsoft.AspNetCore.Mvc;

namespace Api.Funcionalidades.Centrales
{
    public static class CentralEndpoints
    {
        public static RouteGroupBuilder MapCentralEndpoints(this RouteGroupBuilder group)
        {
            group.MapGet("/", async ([FromServices] CentralService centralService) =>
            {
                var centrales = await centralService.ObtenerCentralesAsync();
                return Results.Ok(centrales);
            })
            .WithName("ObtenerCentrales")
            .WithTags("Centrales");

            group.MapGet("/{idCentral}", async ([FromServices] CentralService centralService, int idCentral) =>
            {
                var central = await centralService.ObtenerCentralPorIdAsync(idCentral);
                if (central == null) return Results.NotFound();
                return Results.Ok(central);
            })
            .WithName("ObtenerCentralPorId")
            .WithTags("Centrales");

            group.MapPost("/", async ([FromServices] CentralService centralService, [FromBody] CentralCommandDto centralDto) =>
            {
                var nuevaCentral = await centralService.CrearCentralAsync(centralDto);
                return Results.Created($"/api/centrales/{nuevaCentral.IdCentral}", nuevaCentral);
            })
            .WithName("CrearCentral")
            .WithTags("Centrales");

            group.MapPut("/{idCentral}", async ([FromServices] CentralService centralService, int idCentral, [FromBody] CentralCommandDto centralDto) =>
            {
                var central = await centralService.ActualizarCentralAsync(idCentral, centralDto);
                if (central == null) return Results.NotFound();
                return Results.Ok(central);
            })
            .WithName("ActualizarCentral")
            .WithTags("Centrales");

            group.MapDelete("/{idCentral}", async ([FromServices] CentralService centralService, int idCentral) =>
            {
                var resultado = await centralService.EliminarCentralAsync(idCentral);
                if (!resultado) return Results.NotFound();
                return Results.NoContent();
            })
            .WithName("EliminarCentral")
            .WithTags("Centrales");

            return group;
        }
    }
} 