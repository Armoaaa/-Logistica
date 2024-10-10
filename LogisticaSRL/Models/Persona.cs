using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogisticaSRL.Models
{
    public class Persona
    {
        public int Id { get; set; }
        public int TipoDNIId { get; set; }
        public TipoDNI TipoDNI { get; set; }
        public int DomicilioId { get; set; }
        public Domicilio Domicilio { get; set; }
        public string DNI { get; set; }
        public string PaisResidente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
    }
}