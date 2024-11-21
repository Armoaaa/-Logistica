namespace Api.Funcionalidades
{
    public class DomicilioQueryDto
    {
        public Guid Id { get; set; } // Agregar GUID
        public string Pais { get; set; }
        public string Ciudad { get; set; }
        public string Calle { get; set; }
        public int Numero { get; set; }
        public string CodigoPostal { get; set; }
    }

    public class DomicilioCommandDto
    {
        public Guid Id { get; set; } // Agregar GUID
        public string Pais { get; set; }
        public string Ciudad { get; set; }
        public string Calle { get; set; }
        public int Numero { get; set; }
        public string CodigoPostal { get; set; }
    }
}