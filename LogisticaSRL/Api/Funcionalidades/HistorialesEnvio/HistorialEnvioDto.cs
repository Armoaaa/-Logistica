using Biblioteca.Dominio;

namespace Api.Funcionalidades.HistorialesEnvio
{
    public class HistorialEnvioQueryDto
    {
        public int IdHistorialEnvio { get; set; }
        public int NumeroSeguimiento { get; set; }
        public Envio envio { get; set; }
        public int SucursalId { get; set; }
        public Sucursal sucursal { get; set; }
        public EstadoEnvio estadoEnvio { get; set; }
        public DateTime FechaCambio { get; set; }
        public DateTime FechaCreacion { get; set; }
    }

    public class HistorialEnvioCommandDto
    {
        public int NumeroSeguimiento { get; set; }
        public int SucursalId { get; set; }
        public EstadoEnvio estadoEnvio { get; set; }
    }
}