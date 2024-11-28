using Microsoft.AspNetCore.Mvc;
using Biblioteca.Dominio;

namespace Api.Funcionalidades.Sucursales
{
    public static class SucursalEndpoints
    {
        public static RouteGroupBuilder MapSucursalEndpoints(this RouteGroupBuilder group)
        {
            group.MapGet("/", async ([FromServices] SucursalService sucursalService) =>
            {
                var sucursales = await sucursalService.ObtenerSucursalesAsync();
                return Results.Ok(sucursales);
            })
            .WithName("ObtenerSucursales")
            .WithTags("Sucursales");

            group.MapGet("/{idSucursal}", async ([FromServices] SucursalService sucursalService, int idSucursal) =>
            {
                var sucursal = await sucursalService.ObtenerSucursalPorIdAsync(idSucursal);
                if (sucursal == null) return Results.NotFound();
                return Results.Ok(sucursal);
            })
            .WithName("ObtenerSucursalPorId")
            .WithTags("Sucursales");

            group.MapPost("/", async ([FromServices] SucursalService sucursalService, [FromBody] SucursalCommandDto sucursalDto) =>
            {
                var nuevaSucursal = await sucursalService.CrearSucursalAsync(sucursalDto);
                return Results.Created($"/api/sucursales/{nuevaSucursal.IdSucursal}", nuevaSucursal);
            })
            .WithName("CrearSucursal")
            .WithTags("Sucursales");

            group.MapPut("/{idSucursal}", async ([FromServices] SucursalService sucursalService, int idSucursal, [FromBody] SucursalCommandDto sucursalDto) =>
            {
                var sucursal = await sucursalService.ActualizarSucursalAsync(idSucursal, sucursalDto);
                if (sucursal == null) return Results.NotFound();
                return Results.Ok(sucursal);
            })
            .WithName("ActualizarSucursal")
            .WithTags("Sucursales");

            group.MapDelete("/{idSucursal}", async ([FromServices] SucursalService sucursalService, int idSucursal) =>
            {
                var resultado = await sucursalService.EliminarSucursalAsync(idSucursal);
                if (!resultado) return Results.NotFound();
                return Results.NoContent();
            })
            .WithName("EliminarSucursal")
            .WithTags("Sucursales");

            return group;
        }
    }
}