using Microsoft.AspNetCore.Mvc;

namespace Api.Funcionalidades.Personas
{
    public static class PersonaEndpoints
    {
        public static RouteGroupBuilder MapPersonaEndpoints(this RouteGroupBuilder group)
        {
            group.MapGet("/", async ([FromServices] PersonaService personaService) =>
            {
                var personas = await personaService.ObtenerPersonasAsync();
                return Results.Ok(personas);
            })
            .WithName("ObtenerPersonas")
            .WithTags("Personas");

            group.MapGet("/{idPersona}", async ([FromServices] PersonaService personaService, int idPersona) =>
            {
                var persona = await personaService.ObtenerPersonaPorIdAsync(idPersona);
                if (persona == null) return Results.NotFound();
                return Results.Ok(persona);
            })
            .WithName("ObtenerPersonaPorId")
            .WithTags("Personas");

            group.MapPost("/", async ([FromServices] PersonaService personaService, [FromBody] PersonaCommandDto personaDto) =>
            {
                var nuevaPersona = await personaService.CrearPersonaAsync(personaDto);
                return Results.Created($"/api/personas/{nuevaPersona.IdPersona}", nuevaPersona);
            })
            .WithName("CrearPersona")
            .WithTags("Personas");

            group.MapPut("/{idPersona}", async ([FromServices] PersonaService personaService, int idPersona, [FromBody] PersonaCommandDto personaDto) =>
            {
                var persona = await personaService.ActualizarPersonaAsync(idPersona, personaDto);
                if (persona == null) return Results.NotFound();
                return Results.Ok(persona);
            })
            .WithName("ActualizarPersona")
            .WithTags("Personas");

            group.MapDelete("/{idPersona}", async ([FromServices] PersonaService personaService, int idPersona) =>
            {
                var resultado = await personaService.EliminarPersonaAsync(idPersona);
                if (!resultado) return Results.NotFound();
                return Results.NoContent();
            })
            .WithName("EliminarPersona")
            .WithTags("Personas");

            return group;
        }
    }
}