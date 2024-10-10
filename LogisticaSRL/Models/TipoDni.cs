using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogisticaSRL.Models
{
public class TipoDNI
{
    [Key]
    public int IdTipoDni { get; set; }
    [Required]
    public bool DNIextranjero { get; set; }
    [Required]
    [StringLength(50)]
    public string Pais { get; set; }
}
}