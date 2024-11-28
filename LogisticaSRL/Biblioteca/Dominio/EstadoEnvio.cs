namespace Biblioteca.Dominio;

public enum EstadoEnvio
{
    Creado,
    EnProceso,
    EnTransito,
    EnSucursal,
    EnReparto,
    Entregado,
    Cancelado,
    Devuelto
}