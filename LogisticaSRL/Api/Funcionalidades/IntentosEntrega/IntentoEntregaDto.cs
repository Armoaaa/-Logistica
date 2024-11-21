namespace Api.Funcionalidades
{
    public class IntentoEntregaQueryDto
    {
        public Guid Id { get; set; } // Agregar GUID
        public int NumeroSeguimiento { get; set; }
        public int SucursalId { get; set; }
        public int NumeroIntento { get; set; }
        public bool Entregado { get; set; }
        public DateTime FechaIntento { get; set; }
    }

    public class IntentoEntregaCommandDto
    {
        public Guid Id { get; set; } // Agregar GUID
        public int NumeroSeguimiento { get; set; }
        public int SucursalId { get; set; }
        public int NumeroIntento { get; set; }
        public bool Entregado { get; set; }
        public DateTime FechaIntento { get; set; }
    }
} 