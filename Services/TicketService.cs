using System.Linq;

public class TicketService
{
    private readonly ApplicationDbContext _context;

    public TicketService(ApplicationDbContext context)
    {
        _context = context;
    }

    public bool ValidateSeatAvailability(int trainId, string seatCategory)
    {
        var train = _context.Trains.Find(trainId);
        if (train == null)
        {
            return false; // Tren no encontrado
        }

        var tickets = _context.Tickets.Where(t => t.TrainId == trainId && t.SeatCategory == seatCategory).Count();

        switch (seatCategory)
        {
            case "Premium":
                return tickets < 4 * train.PassengerCapacity; // 4 asientos premium por vagón
            case "Executive":
                return tickets < 8 * train.PassengerCapacity; // 8 asientos ejecutivos por vagón
            case "Standard":
                return tickets < 22 * train.PassengerCapacity; // 22 asientos estándar por vagón
            default:
                return false; // Categoría inválida
        }
    }
}