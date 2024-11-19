using Api.Persistencia;
using Scalar.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Biblioteca.Dominio;
using Pomelo.EntityFrameworkCore.MySql;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = "Server=localhost;Database=LogisticaSRL;User=root;Password=;";
if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("Connection string 'LogisticaBD' not found.");
}
builder.Services.AddDbContext<GestionPedidoDbContext>(options => 
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));    

var options = new DbContextOptionsBuilder<GestionPedidoDbContext>();
options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

var context = new GestionPedidoDbContext(options.Options);

context.Database.EnsureCreated();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var scopedContext = scope.ServiceProvider.GetRequiredService<GestionPedidoDbContext>();
    scopedContext.Database.EnsureCreated();

    // Inicializar datos de prueba
    if (!context.Envios.Any())
    {
        context.Envios.Add(new Envio
        {
            NumeroSeguimiento = 1,
            Dimensiones = "10x10x10",
            Peso = 1.5m,
            // Otros campos necesarios
        });
        context.SaveChanges();
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(options =>
    {
        options.RouteTemplate = "/openapi/{documentName}.json";
    });
    app.MapScalarApiReference();
    app.UseHttpsRedirection();
}

app.Run();
