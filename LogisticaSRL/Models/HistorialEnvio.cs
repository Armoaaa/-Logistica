using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LogisticaSRL.Models;

public class HistorialEnvio
{
    [Key]
    public int IdHistorialEnvio { get; set; }

    [Required]
    public int NumeroSeguimiento { get; set; }
    public Envio envio { get; set; }

    [Required]
    public int SucursalId { get; set; }
    public Sucursal sucursal { get; set; }

    public EstadoEnvio estadoEnvio { get; set; }

    [Required]
    public EstadoEnvio estadoEnvio { get; set; }

    [Required]
    public DateTime FechaCambio { get; set; }
    [Required]
    public DateTime FechaCreacion { get; set; }

}