namespace Api.Funcionalidades
{
    public class SucursalQueryDto
    {
        public Guid Id { get; set; } // Agregar GUID
        public int NumeroS { get; set; }
        public string Nombre { get; set; }
        public int DomicilioId { get; set; }
        public int IdCentral { get; set; }
    }

    public class SucursalCommandDto
    {
        public Guid Id { get; set; } // Agregar GUID
        public int NumeroS { get; set; }
        public string Nombre { get; set; }
        public int DomicilioId { get; set; }
        public int IdCentral { get; set; }
    }
} 