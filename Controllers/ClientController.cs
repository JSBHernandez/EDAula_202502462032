using Microsoft.AspNetCore.Mvc;
using EDAula_202502462032.Models;

namespace EDAula_202502462032.Controllers
{
    public class ClientController : Controller
    {
        // GET: /Client/TicketDemo
        [HttpGet]
        public IActionResult TicketDemo()
        {
            // Datos iniciales para el formulario
            var ticket = new TicketDemoViewModel
            {
                TrainId = "T001", // Tren predeterminado
                DepartureDateTime = "2025-05-14 12:00 PM",
                ArrivalDateTime = "2025-05-14 02:30 PM",
                TicketPrice = 150.00m
            };

            return View(ticket);
        }

        // POST: /Client/TicketDemo
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult TicketDemo(TicketDemoViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Simular la confirmación del boleto
                return View("TicketConfirmation", model);
            }

            // Si hay errores, recargar el formulario
            return View(model);
        }
    }
}