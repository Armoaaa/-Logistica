using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca.Dominio;

public class Central
{
    [Key]
    public int IdCentral { get; set; }

    public string Nombre { get; set; }
    [ForeignKey("IdDomicilio")]
    public int DomicilioId { get; set; }
    [Required]
    public Domicilio domicilio { get; set; }
    public ICollection<Sucursal> Sucursales { get; set; }
}