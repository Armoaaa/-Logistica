namespace Api.Funcionalidades
{
    public class EnviosQueryDto
    {
        public Guid Id { get; set; }
        public int NumeroSeguimiento { get; set; }
        public string PersonaEmisora { get; set; }
        public string PersonaReceptora { get; set; }
        public string SucursalDespacho { get; set; }
        public string SucursalDestino { get; set; }
        public string CentralDespacho { get; set; }
        public string CentralDestino { get; set; }
        public string EstadoEnvio { get; set; }
        public string Dimensiones { get; set; }
        public decimal Peso { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActualizacion { get; set; }
    }

    public class EnviosCommandDto
    {
        public Guid Id { get; set; }
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