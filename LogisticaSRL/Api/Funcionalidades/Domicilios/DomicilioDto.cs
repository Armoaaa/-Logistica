using Biblioteca.Dominio;

namespace Api.Funcionalidades.Domicilios
{
    public class DomicilioQueryDto
    {
        public int IdDomicilio { get; set; }
        public string Pais { get; set; }
        public string Ciudad { get; set; }
        public string Calle { get; set; }
        public int Numero { get; set; }
        public string CodigoPostal { get; set; }
    }

    public class DomicilioCommandDto
    {
        public string Pais { get; set; }
        public string Ciudad { get; set; }
        public string Calle { get; set; }
        public int Numero { get; set; }
        public string CodigoPostal { get; set; }
    }
}