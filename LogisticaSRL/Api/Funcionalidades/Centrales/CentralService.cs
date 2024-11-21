using Api.Persistencia;
using Biblioteca.Dominio;
using Microsoft.EntityFrameworkCore;

namespace Api.Funcionalidades.Centrales;

public class CentralService
{
    private readonly GestionPedidoDbContext _context;

    public CentralService(GestionPedidoDbContext context)
    {
        _context = context;
    }

    public async Task<Central> CreateCentralAsync(CentralCommandDto dto)
    {
        var central = new Central
        {
            Nombre = dto.Nombre,
            DomicilioId = dto.DomicilioId
        };

        _context.Centrales.Add(central);
        await _context.SaveChangesAsync();
        return central;
    }
} 