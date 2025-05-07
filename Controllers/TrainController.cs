using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EDAula_202502462032.Models;
using EDAula_202502462032.Data;

public class TrainController : Controller
{
    private readonly ApplicationDbContext _context;

    public TrainController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: /Train
    public IActionResult Index()
    {
        var trains = _context.Trains.ToList();
        return View(trains);
    }

    // GET: /Train/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: /Train/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Train train)
    {
        if (ModelState.IsValid)
        {
            _context.Trains.Add(train);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        return View(train);
    }

    // GET: /Train/Edit/{id}
    public IActionResult Edit(int id)
    {
        var train = _context.Trains.Find(id);
        if (train == null)
        {
            return NotFound();
        }
        return View(train);
    }

    // POST: /Train/Edit/{id}
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, Train train)
    {
        if (id != train.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            _context.Update(train);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        return View(train);
    }

    // GET: /Train/Delete/{id}
    public IActionResult Delete(int id)
    {
        var train = _context.Trains.Find(id);
        if (train == null)
        {
            return NotFound();
        }
        return View(train);
    }

    // POST: /Train/Delete/{id}
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        var train = _context.Trains.Find(id);
        _context.Trains.Remove(train);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
}