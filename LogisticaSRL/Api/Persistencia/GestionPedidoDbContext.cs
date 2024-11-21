using Microsoft.EntityFrameworkCore;
using Biblioteca.Dominio;

namespace Api.Persistencia
{
    public class GestionPedidoDbContext : DbContext
    {
        public GestionPedidoDbContext(DbContextOptions<GestionPedidoDbContext> options) : base(options)
        {
        }

        public DbSet<Envio>? Envios { get; set; }
        public DbSet<HistorialEnvio>? HistorialesEnvio { get; set; }
        public DbSet<IntentoEntrega>? IntentosEntrega { get; set; }
        public DbSet<Sucursal>? Sucursales { get; set; }
        public DbSet<Central>? Centrales { get; set; }
        public DbSet<Persona>? Personas { get; set; }
        public DbSet<Domicilio>? Domicilios { get; set; }
    }
}