using Biblioteca.Dominio;

namespace Api.Funcionalidades.IntentosEntrega
{
    public class IntentoEntregaQueryDto
    {
        public int IdIntentoEntrega { get; set; }
        public int NumeroSeguimiento { get; set; }
        public Envio Envio { get; set; }
        public int SucursalId { get; set; }
        public Sucursal sucursal { get; set; }
        public int NumeroIntento { get; set; }
        public bool Entregado { get; set; }
        public DateTime FechaIntento { get; set; }
        public DateTime FechaCreacion { get; set; }
    }

    public class IntentoEntregaCommandDto
    {
        public int NumeroSeguimiento { get; set; }
        public int SucursalId { get; set; }
        public bool Entregado { get; set; }
    }
} 