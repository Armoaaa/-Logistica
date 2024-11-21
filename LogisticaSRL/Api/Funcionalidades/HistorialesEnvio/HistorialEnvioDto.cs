 namespace Api.Funcionalidades
{
    using Biblioteca.Dominio; // Asegúrate de que este es el espacio de nombres correcto

    public class HistorialEnvioQueryDto
    {
        public Guid Id { get; set; } // Agregar GUID
        public int NumeroSeguimiento { get; set; }
        public int SucursalId { get; set; }
        public EstadoEnvio EstadoEnvio { get; set; }
        public DateTime FechaCambio { get; set; }
        public DateTime FechaCreacion { get; set; }
    }

    public class HistorialEnvioCommandDto
    {
        public Guid Id { get; set; } // Agregar GUID
        public int NumeroSeguimiento { get; set; }
        public int SucursalId { get; set; }
        public EstadoEnvio EstadoEnvio { get; set; }
        public DateTime FechaCambio { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}