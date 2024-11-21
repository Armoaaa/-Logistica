namespace Api.Funcionalidades
{
    public class PersonaQueryDto
    {
        public Guid Id { get; set; } // Agregar GUID
        public int TipoDNIId { get; set; }
        public int DomicilioId { get; set; }
        public int DNI { get; set; }
        public string PaisResidente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
    }

    public class PersonaCommandDto
    {
        public Guid Id { get; set; } // Agregar GUID
        public int TipoDNIId { get; set; }
        public int DomicilioId { get; set; }
        public int DNI { get; set; }
        public string PaisResidente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
    }
} 