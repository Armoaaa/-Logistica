using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LogisticaSRL.Models
{
    public class HistorialEnvio
    {
        public int Id { get; set; }

        [Required]
        public int EnvioId { get; set; }
        public Envio Envio { get; set; }

        [Required]
        public int SucursalId { get; set; }
        public Sucursal Sucursal { get; set; }

        [Required]
        public EstadoEnvio EstadoAnterior { get; set; }

        [Required]
        public EstadoEnvio EstadoNuevo { get; set; }

        [Required]
        public DateTime FechaCambio { get; set; }

        [StringLength(255)]
        public string Descripcion { get; set; }

        [Required]
        [StringLength(100)]
        public string CreadoPor { get; set; }

        [Required]
        public DateTime FechaCreacion { get; set; }

        [StringLength(500)]
        public string Observaciones { get; set; }
    }
}