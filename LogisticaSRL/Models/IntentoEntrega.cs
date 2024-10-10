using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LogisticaSRL.Models
{
    public class IntentoEntrega
    {
        public int IdIntentoEntrega { get; set; }

        [Required]
        public int EnvioId { get; set; }
        public Envio Envio { get; set; }

        [Required]
        public int SucursalId { get; set; }
        public Sucursal Sucursal { get; set; }

        [Required]
        public bool Entregado { get; set; }

        [Required]
        public DateTime FechaIntento { get; set; }

        [StringLength(500)]
        public string Observaciones { get; set; }
    }
}