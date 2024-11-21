namespace Api.Funcionalidades
{
    public class CentralQueryDto
    {
        public Guid Id { get; set; } // Agregar GUID
        public string Nombre { get; set; }
        public int DomicilioId { get; set; }
    }

    public class CentralCommandDto
    {
        public Guid Id { get; set; } // Agregar GUID
        public string Nombre { get; set; }
        public int DomicilioId { get; set; }
    }
} 