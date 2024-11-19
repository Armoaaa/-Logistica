using System.ComponentModel.DataAnnotations;
namespace Biblioteca.Dominio;

public class Domicilio
{
    [Key]
    public int Id { get; set; }
    public string Pais { get; set;}
    public string Ciudad { get; set; }

    public string Calle { get; set; }
    public int Numero { get; set; }
    public string CodigoPostal { get; set; }
}