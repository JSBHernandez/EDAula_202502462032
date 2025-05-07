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
        var passengers = _context.Passengers.ToList();
        return View(passengers);
    }

    // GET: /Passenger/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: /Passenger/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Passenger passenger)
    {
        if (ModelState.IsValid)
        {
            _context.Passengers.Add(passenger);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        return View(passenger);
    }

    // GET: /Passenger/Edit/{id}
    public IActionResult Edit(int id)
    {
        var passenger = _context.Passengers.Find(id);
        if (passenger == null)
        {
            return NotFound();
        }
        return View(passenger);
    }

    // POST: /Passenger/Edit/{id}
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, Passenger passenger)
    {
        if (id != passenger.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            _context.Update(passenger);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        return View(passenger);
    }

    // GET: /Passenger/Delete/{id}
    public IActionResult Delete(int id)
    {
        var passenger = _context.Passengers.Find(id);
        if (passenger == null)
        {
            return NotFound();
        }
        return View(passenger);
    }

    // POST: /Passenger/Delete/{id}
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        var passenger = _context.Passengers.Find(id);
        if (passenger != null)
        {
            _context.Passengers.Remove(passenger);
            _context.SaveChanges();
        }
        return RedirectToAction(nameof(Index));
    }
}