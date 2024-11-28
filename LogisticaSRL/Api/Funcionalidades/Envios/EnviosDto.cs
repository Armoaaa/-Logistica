using Biblioteca.Dominio;

namespace Api.Funcionalidades.Envios
{
    public class EnviosQueryDto
    {
        public int NumeroSeguimiento { get; set; }
        public int IdPersonaEmisora { get; set; }
        public Persona personaEmisora { get; set; }
        public int IdPersonaReceptora { get; set; }
        public Persona personaReceptora { get; set; }
        public int SucursalDespachoId { get; set; }
        public Sucursal sucursalDespacho { get; set; }
        public int SucursalDestinoId { get; set; }
        public Sucursal sucursalDestino { get; set; }
        public int CentralDespachoId { get; set; }
        public Central centralDespacho { get; set; }
        public int CentralDestinoId { get; set; }
        public Central centralDestino { get; set; }
        public EstadoEnvio estadoEnvio { get; set; }
        public string Dimensiones { get; set; }
        public decimal Peso { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public ICollection<HistorialEnvio> Historiales { get; set; }
    }

    public class EnviosCommandDto
    {
        public int IdPersonaEmisora { get; set; }
        public int IdPersonaReceptora { get; set; }
        public int SucursalDespachoId { get; set; }
        public int SucursalDestinoId { get; set; }
        public int CentralDespachoId { get; set; }
        public int CentralDestinoId { get; set; }
        public string Dimensiones { get; set; }
        public decimal Peso { get; set; }
    }
} 