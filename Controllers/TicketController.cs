using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Models = EDAula_202502462032.Models;

public class TicketController : Controller
{
    // Simula una base de datos de tickets
    private static List<Models.Ticket> _tickets = new List<Models.Ticket>();

    // GET: /Ticket
    public IActionResult Index()
    {
        return View(_tickets); // Muestra todos los tickets
    }

    // POST: /Ticket/Buy
    [HttpPost]
    public IActionResult Buy([FromBody] Models.Ticket ticket)
    {
        _tickets.Add(ticket); // Simula la compra de un ticket
        return Ok(new { Message = "Ticket comprado exitosamente", Ticket = ticket });
    }

    // GET: /Ticket/Details/{id}
    public IActionResult Details(int id)
    {
        var ticket = _tickets.Find(t => t.Id == id);
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
        var ticket = _tickets.Find(t => t.Id == id);
        if (ticket == null)
        {
            return NotFound(new { Message = "Ticket no encontrado" });
        }
        _tickets.Remove(ticket); // Simula la cancelación del ticket
        return Ok(new { Message = $"Ticket con ID {id} cancelado exitosamente" });
    }
}