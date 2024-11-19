   using Microsoft.EntityFrameworkCore;
   using Microsoft.EntityFrameworkCore.Design;
   using Microsoft.Extensions.Configuration;
   using System.IO;

   namespace Api.Persistencia
   {
       public class GestionPedidoBdContextFactory : IDesignTimeBdContextFactory<GestionPedidoBdContext>
       {
           public GestionPedidoBdContext CreateDbContext(string[] args)
           {
               var optionsBuilder = new BdContextOptionsBuilder<GestionPedidoBdContext>();
               var configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();

               var connectionString = configuration.GetConnectionString("DefaultConnection");
               optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

               return new GestionPedidoBdContext(optionsBuilder.Options);
           }
       }
   }