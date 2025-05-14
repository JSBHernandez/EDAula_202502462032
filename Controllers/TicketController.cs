using Microsoft.AspNetCore.Mvc;
using EDAula_202502462032.Models;
using EDAula_202502462032.Data;
using System.Linq;

namespace EDAula_202502462032.Controllers
{
    public class TicketController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TicketController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Ticket
        public IActionResult Index()
        {
            var tickets = _context.Tickets.ToList();
            return View(tickets); // Muestra todos los tickets
        }

        // POST: /Ticket/Buy
        [HttpPost]
        public IActionResult Buy([FromBody] Ticket ticket)
        {
            ticket.PurchaseDateTime = DateTime.Now;
            _context.Tickets.Add(ticket);
            _context.SaveChanges();
            return Ok(new { Message = "Ticket comprado exitosamente", Ticket = ticket });
        }

        // GET: /Ticket/Details/{id}
        public IActionResult Details(int id)
        {
            var ticket = _context.Tickets.Find(id);
            if (ticket == null)
            {
                return NotFound(new { Message = "Ticket no encontrado" });
            }
            return View(ticket); // Muestra los detalles del ticket
        }

        // DELETE: /Ticket/Cancel/{id}
        [HttpDelete("{id}")]
        public IActionResult Cancel(int id)
        {
            var ticket = _context.Tickets.Find(id);
            if (ticket == null)
            {
                return NotFound(new { Message = "Ticket no encontrado" });
            }
            _context.Tickets.Remove(ticket);
            _context.SaveChanges();
            return Ok(new { Message = $"Ticket con ID {id} cancelado exitosamente" });
        }

        // GET: /Ticket/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View(new Ticket());
        }

        // POST: /Ticket/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                ticket.PurchaseDateTime = DateTime.Now;
                _context.Tickets.Add(ticket);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ticket);
        }

        // GET: /Ticket/BoardingOrder
        [HttpGet]
        public IActionResult BoardingOrder()
        {
            var tickets = _context.Tickets
                .OrderByDescending(t => t.PassengerCategory) // Ordenar por categoría
                .ThenBy(t => t.Seat) // Ordenar por lugar
                .ToList();

            return View(tickets);
        }
    }
}