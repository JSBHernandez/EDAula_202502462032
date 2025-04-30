using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Models = EDAula_202502462032.Models; // Alias para los modelos
using EDAula_202502462032.Data;

public class RouteController : Controller
{
    private readonly ApplicationDbContext _context;

    public RouteController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: /Route
    public IActionResult Index()
    {
        // Simula obtener todas las rutas
        var routes = new List<Models.Route>
        {
            new Models.Route { Id = 1, Origin = "Ciudad A", Destination = "Ciudad B", Distance = 100 },
            new Models.Route { Id = 2, Origin = "Ciudad B", Destination = "Ciudad C", Distance = 200 }
        };
        return View(routes); // Pasa las rutas simuladas a la vista
    }

    // POST: /Route/Create
    [HttpPost]
    public IActionResult Create([FromBody] Models.Route route)
    {
        // Simula la creación de una ruta
        return Ok(new { Message = "Ruta creada exitosamente", Route = route });
    }

    // PUT: /Route/Edit/{id}
    [HttpPut("{id}")]
    public IActionResult Edit(int id, [FromBody] Models.Route route)
    {
        // Simula la edición de una ruta
        return Ok(new { Message = $"Ruta con ID {id} actualizada exitosamente", Route = route });
    }

    // DELETE: /Route/Delete/{id}
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        // Simula la eliminación de una ruta
        return Ok(new { Message = $"Ruta con ID {id} eliminada exitosamente" });
    }

    // GET: /Route/ShortestRoute
    [HttpGet("ShortestRoute")]
    public IActionResult ShortestRoute(string origin, string destination)
    {
        // Simula encontrar la ruta más corta
        var shortestRoute = new List<Models.Route>
        {
            new Models.Route { Id = 1, Origin = origin, Destination = destination, Distance = 50 }
        };
        return Ok(shortestRoute);
    }
}