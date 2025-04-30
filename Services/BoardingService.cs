using System.Collections.Generic;
using System.Linq;

public class BoardingService
{
    private readonly ApplicationDbContext _context;

    public BoardingService(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<Ticket> GetBoardingOrder(int trainId)
    {
        var tickets = _context.Tickets
            .Where(t => t.TrainId == trainId)
            .OrderByDescending(t => t.SeatCategory) // Ordenar por categoría (Premium > Ejecutivo > Estándar)
            .ThenByDescending(t => t.Id) // Ordenar de atrás hacia adelante
            .ToList();

        return tickets;
    }
}