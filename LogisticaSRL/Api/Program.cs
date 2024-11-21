using Api.Persistencia;
using Microsoft.EntityFrameworkCore;
using Api.Funcionalidades.Centrales;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<GestionPedidoDbContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));    

var options = new DbContextOptionsBuilder<GestionPedidoDbContext>();
options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

var context = new GestionPedidoDbContext(options.Options);

context.Database.EnsureCreated();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseHttpsRedirection();
}

// Asegurar que la base de datos esté creada
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<GestionPedidoDbContext>();
    context.Database.EnsureCreated();
}

// Mapear endpoints
app.MapPost("/Centrales", async (CentralService centralService, CentralCommandDto dto) =>
{
    var result = await centralService.CreateCentralAsync(dto);
    return Results.Created($"/Centrales/{result.IdCentral}", result);
});

app.Run();