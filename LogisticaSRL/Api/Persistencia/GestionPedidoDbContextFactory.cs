   using Microsoft.EntityFrameworkCore;
   using Microsoft.EntityFrameworkCore.Design;
   using Microsoft.Extensions.Configuration;
   using System.IO;

   namespace Api.Persistencia
   {
       public class GestionPedidoDbContextFactory : IDesignTimeDbContextFactory<GestionPedidoDbContext>
       {
           public GestionPedidoDbContext CreateDbContext(string[] args)
           {
               var optionsBuilder = new DbContextOptionsBuilder<GestionPedidoDbContext>();
               var configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();

               var connectionString = configuration.GetConnectionString("DefaultConnection");
               optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

               return new GestionPedidoDbContext(optionsBuilder.Options);
           }
       }
   }