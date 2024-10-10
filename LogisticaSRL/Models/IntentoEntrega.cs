using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LogisticaSRL.Models
{
    public class IntentoEntrega
    {
        [Key]
        public int IdIntentoEntrega { get; set; }

        [ForeignKey("NumeroSeguimiento")]
        public int NumeroSeguimiento { get; set; }
        [Required]
        public Envio Envio { get; set; }

        [ForeignKey("IdSucursal")]
        public int SucursalId { get; set; }
        [Required]
        public Sucursal Sucursal { get; set; }
        public int NumeroIntento { get; set; }
        [Required]
        public bool Entregado { get; set; }

        [Required]
        public DateTime FechaIntento { get; set; }

    }
}