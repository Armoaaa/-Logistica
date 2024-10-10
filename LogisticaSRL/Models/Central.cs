using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogisticaSRL.Models
{
    public class Central
    {
        public int IdCentral { get; set; }
        public string Nombre { get; set; }
        public int DomicilioId { get; set; }
        public Domicilio Domicilio { get; set; }
        public ICollection<Surcusal> Surcusal { get; set; }
    }
}