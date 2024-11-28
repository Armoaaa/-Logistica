using Biblioteca.Dominio;

namespace Api.Funcionalidades.Centrales
{
    public class CentralQueryDto
    {
        public int IdCentral { get; set; }
        public string Nombre { get; set; }
        public int DomicilioId { get; set; }
        public Domicilio domicilio { get; set; }
        public ICollection<Sucursal> Sucursales { get; set; }
    }

    public class CentralCommandDto
    {
        public string Nombre { get; set; }
        public int DomicilioId { get; set; }
    }
} 