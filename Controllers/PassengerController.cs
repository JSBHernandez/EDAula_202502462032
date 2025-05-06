using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EDAula_202502462032.Models;
using System.Linq;
using EDAula_202502462032.Data;

public class PassengerController : Controller
{
    private readonly ApplicationDbContext _context;

    public PassengerController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: /Passenger
    public IActionResult Index()
    {
        var passengers = _context.Passengers.ToList(); // Carga todos los pasajeros
        return View(passengers); // Pasa los datos a la vista
    }
}