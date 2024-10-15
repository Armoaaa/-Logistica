using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LogisticaSRL.Models;

public class Persona
{
    [Key]
    public int IdPersona { get; set; }

    [ForeignKey("IdTipoDNI")]
    public int TipoDNIId { get; set; }
    [Required]
    public TipoDNI TipoDNI { get; set; }

    [ForeignKey("IdDomicilio")]
    public int DomicilioId { get; set; }
    [Required]
    public Domicilio domicilio { get; set; }

    public int DNI { get; set; }

    public string PaisResidente { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
}