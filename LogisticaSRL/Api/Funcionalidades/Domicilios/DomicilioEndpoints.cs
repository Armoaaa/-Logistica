using Microsoft.AspNetCore.Mvc;

namespace Api.Funcionalidades.Domicilios
{
    public static class DomicilioEndpoints
    {
        public static RouteGroupBuilder MapDomicilioEndpoints(this RouteGroupBuilder group)
        {
            group.MapGet("/", async ([FromServices] DomicilioService domicilioService) =>
            {
                var domicilios = await domicilioService.ObtenerDomiciliosAsync();
                return Results.Ok(domicilios);
            })
            .WithName("ObtenerDomicilios")
            .WithTags("Domicilios");

            group.MapGet("/{idDomicilio}", async ([FromServices] DomicilioService domicilioService, int idDomicilio) =>
            {
                var domicilio = await domicilioService.ObtenerDomicilioPorIdAsync(idDomicilio);
                if (domicilio == null) return Results.NotFound();
                return Results.Ok(domicilio);
            })
            .WithName("ObtenerDomicilioPorId")
            .WithTags("Domicilios");

            group.MapPost("/", async ([FromServices] DomicilioService domicilioService, DomicilioCommandDto domicilioDto) =>
            {
                var domicilio = await domicilioService.CrearDomicilioAsync(domicilioDto);
                return Results.Created($"/{domicilio.IdDomicilio}", domicilio);
            })
            .WithName("CrearDomicilio")
            .WithTags("Domicilios");

            group.MapPut("/{idDomicilio}", async ([FromServices] DomicilioService domicilioService, int idDomicilio, DomicilioCommandDto domicilioDto) =>
            {
                var domicilio = await domicilioService.ActualizarDomicilioAsync(idDomicilio, domicilioDto);
                if (domicilio == null) return Results.NotFound();
                return Results.Ok(domicilio);
            })
            .WithName("ActualizarDomicilio")
            .WithTags("Domicilios");

            group.MapDelete("/{idDomicilio}", async ([FromServices] DomicilioService domicilioService, int idDomicilio) =>
            {
                var success = await domicilioService.EliminarDomicilioAsync(idDomicilio);
                if (!success) return Results.NotFound();
                return Results.NoContent();
            })
            .WithName("EliminarDomicilio")
            .WithTags("Domicilios");

            return group;
        }
    }
} 