using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
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
        return Ok(trains); // Devuelve la lista de trenes
    }

    // POST: /Train/Create
    [HttpPost]
    public IActionResult Create([FromBody] Train train)
    {
        if (ModelState.IsValid)
        {
            _context.Trains.Add(train);
            _context.SaveChanges();
            return Ok(train);
        }
        return BadRequest(ModelState);
    }

    // PUT: /Train/Edit/{id}
    [HttpPut("{id}")]
    public IActionResult Edit(int id, [FromBody] Train train)
    {
        var existingTrain = _context.Trains.Find(id);
        if (existingTrain == null)
        {
            return NotFound();
        }

        existingTrain.Name = train.Name;
        existingTrain.Identifier = train.Identifier;
        existingTrain.Type = train.Type;
        existingTrain.PassengerCapacity = train.PassengerCapacity;
        existingTrain.LuggageCapacity = train.LuggageCapacity;
        existingTrain.Mileage = train.Mileage;

        _context.SaveChanges();
        return Ok(existingTrain);
    }

    // DELETE: /Train/Delete/{id}
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var train = _context.Trains.Find(id);
        if (train == null)
        {
            return NotFound();
        }

        _context.Trains.Remove(train);
        _context.SaveChanges();
        return Ok();
    }
}