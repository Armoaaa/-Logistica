
using System.ComponentModel.DataAnnotations;


using System.ComponentModel.DataAnnotations.Schema;
namespace Biblioteca.Dominio;
public class IntentoEntrega
{
    [Key]
    public int IdIntentoEntrega { get; set; }

    [ForeignKey("NumeroSeguimiento")]
    public int NumeroSeguimiento { get; set; }
    [Required]
    public Envio Envio { get; set; }

    [ForeignKey("IdSucursal")]
    public int SucursalId { get; set; }
    [Required]
    public Sucursal sucursal { get; set; }
    public int NumeroIntento { get; set; }
    [Required]
    public bool Entregado { get; set; }

    [Required]
    public DateTime FechaIntento { get; set; }

}