using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogisticaSRL.Models
{
    public class IntentoEntrega
    {
        public int IdIntento { get; set; }
        public Sucursal Sucursal { get; set; }
        public string NumeroSeguimiento { get; set; }
        public bool Entregado { get; set; }
        public DateTime FechaIntento { get; set; }
    }
}