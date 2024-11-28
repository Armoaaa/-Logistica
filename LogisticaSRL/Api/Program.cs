using Api;
using Api.Funcionalidades.Centrales;
using Api.Funcionalidades.Envios;
using Api.Funcionalidades.HistorialesEnvio;
using Api.Funcionalidades.IntentosEntrega;
using Api.Persistencia;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Database configuration
builder.Services.AddDbContext<GestionPedidoDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register ServiceManager
builder.Services.AddScoped<ServiceManager>();

// Register individual services
builder.Services.AddScoped<CentralService>();
builder.Services.AddScoped<EnviosService>();
builder.Services.AddScoped<HistorialEnvioService>();
builder.Services.AddScoped<IntentoEntregaService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Map endpoints
var apiGroup = app.MapGroup("/api");

apiGroup.MapGroup("/centrales")
    .MapCentralEndpoints();

apiGroup.MapGroup("/envios")
    .MapEnviosEndpoints();

apiGroup.MapGroup("/historialesenvio")
    .MapHistorialEnvioEndpoints();

apiGroup.MapGroup("/intentosentrega")
    .MapIntentoEntregaEndpoints();

app.Run();