using Microsoft.AspNetCore.Mvc;
using System.Linq;
using EDAula_202502462032.Models;
using EDAula_202502462032.Data;

public class StationController : Controller
{
    private readonly ApplicationDbContext _context;

    public StationController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: /Station
    public IActionResult Index()
    {
        var stations = _context.Stations.ToList();
        return Ok(stations); // Devuelve la lista de estaciones
    }

    // POST: /Station/Create
    [HttpPost]
    public IActionResult Create([FromBody] Station station)
    {
        if (ModelState.IsValid)
        {
            _context.Stations.Add(station);
            _context.SaveChanges();
            return Ok(station);
        }
        return BadRequest(ModelState);
    }

    // PUT: /Station/Edit/{id}
    [HttpPut("{id}")]
    public IActionResult Edit(int id, [FromBody] Station station)
    {
        var existingStation = _context.Stations.Find(id);
        if (existingStation == null)
        {
            return NotFound();
        }

        existingStation.Name = station.Name;

        _context.SaveChanges();
        return Ok(existingStation);
    }

    // DELETE: /Station/Delete/{id}
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var station = _context.Stations.Find(id);
        if (station == null)
        {
            return NotFound();
        }

        _context.Stations.Remove(station);
        _context.SaveChanges();
        return Ok();
    }
}