using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogisticaSRL.Models
{
    public class Envio
    {
        [Key]
        public int IdEnvio { get; set; }
        public int IdPersonaEmisora { get; set; }
        [ForeignKey("IdPersona")]
        public Persona PersonaEmisora { get; set; }
        [ForeignKey("IdPersona")]
        public int IdPersonaReceptora { get; set; }
        public Persona PersonaReceptora { get; set; }
        [ForeignKey("IdSucursal")]
        public int SucursalDespachoId { get; set; }
        public Sucursal SucursalDespacho { get; set; }
        [ForeignKey("IdSucursal")]
        public int SucursalDestinoId { get; set; }
        public Sucursal SucursalDestino { get; set; }
        [ForeignKey("IdCentral")]
        public int CentralDespachoId { get; set; }
        public Central CentralDespacho { get; set; }
        [ForeignKey("IdCentral")]
        public int CentralDestinoId { get; set; }
        public Central CentralDestino { get; set; }
        [required]
        public EstadoEnvio EstadoEnvio { get; set; }
        public string NumeroSeguimiento { get; set; }
        public string Dimensiones { get; set; }
        public decimal Peso { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public ICollection<HistorialEnvio> Historiales { get; set; }
    }
}