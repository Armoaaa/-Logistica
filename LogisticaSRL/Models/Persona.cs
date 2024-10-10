using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogisticaSRL.Models
{
    public class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int DomicilioId { get; set; }
        public Domicilio Domicilio { get; set; }
        public string PaisResidencia { get; set; }
    }
}