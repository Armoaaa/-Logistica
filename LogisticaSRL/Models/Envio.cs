using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogisticaSRL.Models;

public class Envio
{
    [Key]
    public int NumeroSeguimiento { get; set; }
    [ForeignKey("IdPersona")]
    public int IdPersonaEmisora { get; set; }
    [Required]
    public Persona personaEmisora { get; set; }
    [ForeignKey("IdPersona")]
    public int IdPersonaReceptora { get; set; }
    [Required]
    public Persona personaReceptora { get; set; }
    [ForeignKey("IdSucursal")]
    public int SucursalDespachoId { get; set; }
    [Required]
    public Sucursal sucursalDespacho { get; set; }
    [ForeignKey("IdSucursal")]
    public int SucursalDestinoId { get; set; }
    [Required]
    public Sucursal sucursalDestino { get; set; }
    [ForeignKey("IdCentral")]
    public int CentralDespachoId { get; set; }
    [Required]
    public Central centralDespacho { get; set; }
    [ForeignKey("IdCentral")]
    public int CentralDestinoId { get; set; }
    public Central centralDestino { get; set; }
    [required]
    public EstadoEnvio estadoEnvio { get; set; }
    public string Dimensiones { get; set; }
    public decimal Peso { get; set; }
    public DateTime FechaCreacion { get; set; }
    public DateTime FechaActualizacion { get; set; }
    public ICollection<HistorialEnvio> Historiales { get; set; }
}