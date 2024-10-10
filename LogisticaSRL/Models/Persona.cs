using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LogisticaSRL.Models
{
    public class Persona
    {
        [Key]
        public int IdPersona { get; set; }

        [Required]
        public int TipoDNIId { get; set; }
        public TipoDNI TipoDNI { get; set; }

        [Required]
        public int DomicilioId { get; set; }
        public Domicilio Domicilio { get; set; }

        [Required]
        public int DNI { get; set; }

        public string PaisResidente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
    }
}