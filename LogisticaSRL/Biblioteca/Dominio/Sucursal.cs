using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca.Dominio;

public class Sucursal
{
    [Key]
    public int IdSucursal { get; set; }
    [Required]
    public int NumeroS { get; set; }
    public string Nombre { get; set; }
    public int DomicilioId { get; set; }
    [Required]
    public Domicilio domicilio { get; set; }
    [ForeignKey("IdCentral")]
    public int IdCentral { get; set; }
    public Central Central { get; set; }
}