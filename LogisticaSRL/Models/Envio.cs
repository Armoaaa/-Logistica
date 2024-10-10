using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogisticaSRL.Models
{
    public class Envio
{
    public int Id { get; set; }
    public string NumeroSeguimiento { get; set; }
    public string Dimensiones { get; set; }
    public decimal Peso { get; set; }
    public int RemitenteId { get; set; }
    public Persona Remitente { get; set; }
    public int DestinatarioId { get; set; }
    public Persona Destinatario { get; set; }
    public int SucursalDespachoId { get; set; }
    public Sucursal SucursalDespacho { get; set; }
    public int SucursalDestinoId { get; set; }
    public Sucursal SucursalDestino { get; set; }
    public int CentralDespachoId { get; set; }
    public Central CentralDespacho { get; set; }
    public int CentralDestinoId { get; set; }
    public Central CentralDestino { get; set; }
    public EstadoEnvio Estado { get; set; }
    public int IntentosEntrega { get; set; }
    }
}