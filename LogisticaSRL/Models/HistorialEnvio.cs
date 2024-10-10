using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LogisticaSRL.Models
{
    public class HistorialEnvio
    {
        [Key]
        public int IdHistorialEnvio { get; set; }

            [Required]
        public int EnvioId { get; set; }
        public Envio Envio { get; set; }

        [Required]
        public int SucursalId { get; set; }
        public Sucursal Sucursal { get; set; }

        public EstadoEnvio EstadoAnterior { get; set; }

        [Required]
        public EstadoEnvio EstadoNuevo { get; set; }

        [Required]
        public DateTime FechaCambio { get; set; }
        [Required]
        public DateTime FechaCreacion { get; set; }

    }
}