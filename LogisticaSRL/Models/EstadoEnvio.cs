using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace LogisticaSRL.Models
{
    public enum EstadoEnvio
    {
    SucursalDespacho,
    CentralSucursalDespacho,
    CentralSucursalDestino,
    SucursalDestino,
    IntentoEntrega1,
    IntentoEntrega2,
    IntentoEntrega3,
    EntregaExitosa,
    DisponibleParaRetiro
}
}