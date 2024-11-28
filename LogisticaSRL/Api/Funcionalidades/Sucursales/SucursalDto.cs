using Biblioteca.Dominio;

namespace Api.Funcionalidades.Sucursales

{
    public class SucursalQueryDto
    {
        public int IdSucursal { get; set; }
        public int NumeroS { get; set; }
        public string Nombre { get; set; }
        public int DomicilioId { get; set; }
        public Domicilio Domicilio { get; set; }
        public int IdCentral { get; set; }
        public Central Central { get; set; }
    }

    public class SucursalCommandDto
    {
        public int NumeroS { get; set; }
        public string Nombre { get; set; }
        public int DomicilioId { get; set; }
        public int IdCentral { get; set; }
    }
}