using Biblioteca.Dominio;

namespace Api.Funcionalidades.Personas
{
    public class PersonaQueryDto
    {
        public int IdPersona { get; set; }
        public int TipoDNIId { get; set; }
        public TipoDNI TipoDNI { get; set; }
        public int DomicilioId { get; set; }
        public Domicilio Domicilio { get; set; }
        public int DNI { get; set; }
        public string PaisResidente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
    }

    public class PersonaCommandDto
    {
        public int TipoDNIId { get; set; }
        public int DomicilioId { get; set; }
        public int DNI { get; set; }
        public string PaisResidente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
    }
} 