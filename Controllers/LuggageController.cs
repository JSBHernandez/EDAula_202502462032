using Microsoft.AspNetCore.Mvc;
using System.Linq;

public class LuggageController : Controller
{
    private readonly ApplicationDbContext _context;

    public LuggageController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: /Luggage
    public IActionResult Index()
    {
        var luggages = _context.Luggages.ToList();
        return Ok(luggages); // Devuelve la lista de equipajes
    }

    // POST: /Luggage/Create
    [HttpPost]
    public IActionResult Create([FromBody] Luggage luggage)
    {
        if (ModelState.IsValid)
        {
            var train = _context.Trains.Find(luggage.TrainId);
            if (train == null)
            {
                return NotFound("El tren especificado no existe.");
            }

            // Validar capacidad de equipaje
            var totalLuggageWeight = _context.Luggages
                .Where(l => l.TrainId == luggage.TrainId)
                .Sum(l => l.Weight);

            if (totalLuggageWeight + luggage.Weight > train.LuggageCapacity)
            {
                return BadRequest("El tren no tiene capacidad para más equipaje.");
            }

            _context.Luggages.Add(luggage);
            _context.SaveChanges();
            return Ok(luggage);
        }
        return BadRequest(ModelState);
    }
}