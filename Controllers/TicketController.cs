using Microsoft.AspNetCore.Mvc;
using System.Linq;

public class TicketController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly TicketService _ticketService;

    public TicketController(ApplicationDbContext context, TicketService ticketService)
    {
        _context = context;
        _ticketService = ticketService;
    }

    // GET: /Ticket
    public IActionResult Index()
    {
        var tickets = _context.Tickets.ToList();
        return Ok(tickets); // Devuelve la lista de boletos
    }

    // POST: /Ticket/Purchase
    [HttpPost]
    public IActionResult Purchase([FromBody] Ticket ticket)
    {
        if (ModelState.IsValid)
        {
            // Validar disponibilidad de asientos
            if (!_ticketService.ValidateSeatAvailability(ticket.TrainId, ticket.SeatCategory))
            {
                return BadRequest("No hay asientos disponibles en esta categoría.");
            }

            _context.Tickets.Add(ticket);
            _context.SaveChanges();
            return Ok(ticket);
        }
        return BadRequest(ModelState);
    }
}